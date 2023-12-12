using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultSlot : MonoBehaviour
{
    public Item item; // ȹ���� ������
    public Image itemImage;  // �������� �̹���
    public TextMeshProUGUI clue_text;

    // �κ��丮�� ���ο� ������ ���� �߰�
    public void AddResult(string result)
    {
        clue_text.text = result;
    }

    public void AddMembers(Item _item)
    {
        item = _item;
        if(_item.isAlive == true) //����
        {
            itemImage.sprite = _item.itemImage;
        } else //����
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
