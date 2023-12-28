using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultSlot : MonoBehaviour
{
    public Item item; // 획득한 아이템
    public Image itemImage;  // 아이템의 이미지
    public TextMeshProUGUI clue_text;

    // 인벤토리에 새로운 아이템 슬롯 추가
    public void AddResult(string result)
    {
        clue_text.text = result;
    }

    public void AddMembers(Item _item)
    {
        item = _item;
        if(_item.isAlive == true) //생존
        {
            itemImage.sprite = _item.itemImage;
        } else //죽음
        {
            itemImage.sprite = _item.itemDieImage;
        }
    }
    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
    }

    public void ClearText()
    {
        clue_text.text = "";
    }
}
