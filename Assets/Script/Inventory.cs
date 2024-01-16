using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;

    [SerializeField]
    private GameObject go_InventoryBase; // Inventory_Base 이미지
    [SerializeField]
    private GameObject go_SlotsParent;  // Slot들의 부모인 Grid Setting
    [SerializeField]
    private GameObject go_SlotsParent2;  // Slot들의 부모인 Grid Setting
    [SerializeField] private Item[] items;
    [SerializeField] private GameObject[] clueObj;
    private Slot[] slots;  // 슬롯들 배열
    private Slot[] slots2;

    [SerializeField]
    GameObject dismissalObj;
    [SerializeField]
    GameObject wantedObj;
    [SerializeField]
    GameObject rockObj;
    [SerializeField]
    GameObject drugObj;

    private List<Talent> talents = GameManager.instance.talents;

    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
        slots2 = go_SlotsParent2.GetComponentsInChildren<Slot>();

        CheckInventory();
    }

    void Update()
    {
        //TryOpenInventory();
    }

    /*
    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            invectoryActivated = !invectoryActivated;

            if (invectoryActivated)
                OpenInventory();
            else
                CloseInventory();

        }
    } */

    public void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    public void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    } 

    public void CheckInventory()
    {
        Inventory inven = GameObject.Find("Inventory").GetComponent<Inventory>();

        if (talents[0].haveWeakness == true)
        {
            inven.AcquireItem(dismissalObj.transform.GetComponent<ItemPickUp>().item);
        }

        if (talents[1].haveWeakness == true)
        {
            inven.AcquireItem(wantedObj.transform.GetComponent<ItemPickUp>().item);
        }

        if (talents[2].haveWeakness == true)
        {
            inven.AcquireItem(rockObj.transform.GetComponent<ItemPickUp>().item);
        }

        if (talents[3].haveWeakness == true)
        {
            inven.AcquireItem(drugObj.transform.GetComponent<ItemPickUp>().item);
        }

        for (int i = 1; i <= 5; i++)
        {
            if (GameManager.instance.getClues == i)
            {
                for(int j = 0; j < i; j++)
                {
                    inven.AcquireItem(clueObj[j].transform.GetComponent<ItemPickUp>().item);
                }
                
            }
        }
        
    }
    

    public void AcquireItem(Item _item, int _count = 1)
    {
        /*
        if (Item.ItemType.Commoner == _item.itemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)  // null 이라면 slots[i].item.itemName 할 때 런타임 에러 나서
                {
                    if (slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        }
        */
        if(_item.itemType == Item.ItemType.Weakness)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item == null)
                {
                    slots[i].AddItem(_item, _count);
                    return;
                }
            }
        } else if(_item.itemType == Item.ItemType.Clue)
        {
            for (int i = 0; i < slots2.Length; i++)
            {
                if (slots2[i].item == null)
                {
                    slots2[i].AddItem(_item, _count);
                    return;
                }
            }
        }
    }

    public Slot[] GetSlots()
    {
        return slots;
    }

    public void LoadToInven(int _arrayNum, string _itemName, int _itemNum)
    {
        for (int i = 0; i < items.Length; i++)
            if (items[i].itemName == _itemName)
                slots[_arrayNum].AddItem(items[i], _itemNum);
    }
}
