using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item; // 획득한 아이템
    public int itemCount; // 획득한 아이템의 개수
    public Image itemImage;  // 아이템의 이미지

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;    

    // 아이템 이미지의 투명도 조절
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // 인벤토리에 새로운 아이템 슬롯 추가
    public void AddItem(Item _item, int _count)
    {
        item = _item;
        itemCount += _count;
        itemImage.sprite = item.itemImage;

        if (item.itemType != Item.ItemType.Commoner)
        {
            go_CountImage.SetActive(false);
        }
        else
        {
            text_Count.text = "X " +  itemCount.ToString();
            go_CountImage.SetActive(true);
        }

        SetColor(1);
    }

    // 해당 슬롯의 아이템 갯수 업데이트
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = "X " + itemCount.ToString();

        /*
        if (itemCount <= 0)
            ClearSlot();
        */
    }

    // 해당 슬롯 하나 삭제
    public void ClearExplore()
    {
        ExploreBuild ex = GameObject.Find("ExploreBuild").GetComponent<ExploreBuild>();

        if (item.itemType == Item.ItemType.Talent)
        {
            item.isSelected = false;
        } else if(item.itemType == Item.ItemType.Commoner)
        {
            ex.AcquireCharacter(item, 1);
        }
        
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

    public void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

    public void ItemClicked()
    {
        ExploreBuild ex = GameObject.Find("ExploreBuild").GetComponent<ExploreBuild>();

        if(item != null)
        {
            if (item.isSelected == false)
            {
                ex.BuildExplorer(item, 1);
                item.isSelected = true;
            }
            else
            {
                ex.BuildExplorer(item, 0);
                item.isSelected = false;
            }
        }
    }

    public void CommonerClicked()
    {
        ExploreBuild ex = GameObject.Find("ExploreBuild").GetComponent<ExploreBuild>();

        if(item != null)
        {
            if(itemCount > 0)
            {
                ex.BuildExplorer(item, 1);
                //SetSlotCount(-1);
            }
        }
    }
}
