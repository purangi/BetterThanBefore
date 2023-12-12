using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item; // ȹ���� ������
    public int itemCount; // ȹ���� �������� ����
    public Image itemImage;  // �������� �̹���

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;    

    // ������ �̹����� ���� ����
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // �κ��丮�� ���ο� ������ ���� �߰�
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

    // �ش� ������ ������ ���� ������Ʈ
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = "X " + itemCount.ToString();

        /*
        if (itemCount <= 0)
            ClearSlot();
        */
    }

    // �ش� ���� �ϳ� ����
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
