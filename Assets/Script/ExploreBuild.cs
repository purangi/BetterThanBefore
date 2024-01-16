using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ExploreBuild : MonoBehaviour
{
    public static bool inventoryActivated = false;
    private DialogueRunner dialogueRunner;

    [SerializeField]
    private GameObject go_InventoryBase; // Inventory_Base �̹���
    [SerializeField]
    private GameObject go_SlotsParent;  // Slot���� �θ��� Grid Setting
    [SerializeField]
    private GameObject go_SlotsParent2;  // Slot���� �θ��� Grid Setting
    [SerializeField] private Item[] items;
    private Slot[] slots;  // ���Ե� �迭
    private Slot[] slots2;

    [SerializeField]
    GameObject Knight;
    [SerializeField]
    GameObject Mercenary;
    [SerializeField]
    GameObject Acrobat;
    [SerializeField]
    GameObject Alchem;

    private List<Talent> talents = GameManager.instance.talents;

    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
        slots2 = go_SlotsParent2.GetComponentsInChildren<Slot>();

        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();

        CheckEmploy();
    }

    void Update()
    {
        
    }

    public void OpenExplore()
    {
        go_InventoryBase.SetActive(true);
    }

    public void CloseExplore()
    {
        go_InventoryBase.SetActive(false);
    }

    public void CheckEmploy()
    {
        ExploreBuild exp = GameObject.Find("ExploreBuild").GetComponent<ExploreBuild>();
        if (talents[0].isEmployed)
        {
            exp.AcquireCharacter(Knight.transform.GetComponent<ItemPickUp>().item, 1);
        }
        if (talents[1].isEmployed)
        {
            exp.AcquireCharacter(Mercenary.transform.GetComponent<ItemPickUp>().item, 1);
        }
        if (talents[3].isEmployed)
        {
            exp.AcquireCharacter(Alchem.transform.GetComponent<ItemPickUp>().item, 1);
        }
        if (talents[2].isEmployed)
        {
            exp.AcquireCharacter(Acrobat.transform.GetComponent<ItemPickUp>().item, 1);
        }
        if (GameManager.instance.employCommoner >= 1)
        {
            Item commoner = GameObject.Find("Commoners").GetComponent<ItemPickUp>().item;
            exp.AcquireCharacter(commoner, GameManager.instance.employCommoner);
        }
    }

    public void AcquireCharacter(Item _item, int _count)
    {
        GameObject obj = GameObject.Find("GameManager");

        if(obj != null)
        {
            if (_item.itemType == Item.ItemType.Talent)
            {
                for (int i = 0; i < slots.Length; i++)
                {
                    if (slots[i].item == null)
                    {
                        _count = 1;
                        slots[i].AddItem(_item, _count);
                        return;
                    }
                }
            }
            else if (_item.itemType == Item.ItemType.Commoner)
            {
                slots[4].AddItem(_item, _count);
                return;
            }
        }
    }

    public void BuildExplorer(Item _item, int _count) //���߿� �ڵ� ����
    {
        if (_item.itemType == Item.ItemType.Talent)
        {
            for (int i = 0; i < slots2.Length; i++)
            {
                if (slots2[i].item == null && _count != 0)
                {
                    slots2[i].AddItem(_item, _count);
                    return;
                } else if(slots2[i].item == _item && _count == 0)
                {
                    slots2[i].ClearExplore();
                    return;
                }
            }
        } else if(_item.itemType == Item.ItemType.Commoner)
        {
            for (int i = 0; i < slots2.Length; i++)
            {
                if (slots2[i].item == null)
                {
                    slots2[i].AddItem(_item, _count);
                    slots[4].SetSlotCount(-1);
                    return;
                }
            }
        }
    }

    public Slot[] GetSlots()
    {
        return slots;
    }

    public Slot[] GetSlots2()
    {
        return slots2;
    }

    public void LoadToInven(int _arrayNum, string _itemName, int _itemNum)
    {
        for (int i = 0; i < items.Length; i++)
            if (items[i].itemName == _itemName)
                slots[_arrayNum].AddItem(items[i], _itemNum);
    }

    public void ClearAllSlot()
    {
        for(int i = 0; i < slots2.Length; i++)
        {
            slots2[i].ClearSlot();
        }
    }

    public void StartExplore()
    {
        int explorePercentage = 0;
        int random;
        bool canStart = true;

        for(int i = 0; i < slots2.Length; i++)
        {
            if(slots2[i].item != null) //null�� ���� �߰ߵǸ� ��ư �ȴ������� ����
            {
                if(slots2[i].item.itemType == Item.ItemType.Commoner)
                {
                    random = Random.Range(0, 21);
                    explorePercentage += random;
                } else if(slots2[i].item.itemType == Item.ItemType.Talent)
                {
                    random = Random.Range(10, 31);
                    explorePercentage += random;
                }
            } else
            {
                canStart = false;
            }
        }

        ExploreMessage(explorePercentage, canStart);
    }

    public void ExploreMessage(int percentage, bool canStart)
    {
        string random = Random.Range(1, 5).ToString();

        if(canStart) //��� ���
        {
            CloseExplore();
            if (percentage >= 71)
            {
                dialogueRunner.StartDialogue("ExploreSuccess" + random);
            }
            else
            {
                dialogueRunner.StartDialogue("ExploreFail" + random);
            }
        } else //Ž��븦 �ٸ���� ���
        {
            Debug.Log("Ž��븦 �ٸ�����");
        }
    }

    [YarnCommand("explore_result")]
    public void ExploreResult(string result)
    {
        ExploreResult exr = GameObject.Find("ExploreResult").GetComponent<ExploreResult>();

        exr.OpenExplore();

        int alive = Random.Range(0, 5);
        bool isKnight = false;

        for(int i = 0; i < slots2.Length; i++)
        {
            if(slots2[i].item.itemName == "Knight")
            {
                isKnight = true;
            } else if(slots2[i].item.itemName == "Commoner")
            {
                GameManager.instance.employCommoner -= 1;
            }
        }

        for (int i = 0; i < slots2.Length; i++)
        {
            int random = Random.Range(0, 2);

            if(isKnight == true)
            {
                if (i != alive)
                {
                    if (random == 0)
                    {
                        Debug.Log("��簡 �츰 �ְ� �ƴѵ� �� ���");
                        slots2[i].item.isAlive = true;
                    }
                    else
                    {
                        Debug.Log("��簡 �츰 �ְ� �ƴѵ� ���� ���");
                        slots2[i].item.isAlive = false;
                    }
                }
                else
                {
                    slots2[i].item.isAlive = true;
                    Debug.Log("��簡 �츰 ���� ���" + i + "�츲");
                }
            } else
            {
                Debug.Log("��簡 ���� ���");
                if (random == 0)
                {
                    slots2[i].item.isAlive = true;
                }
                else
                {
                    slots2[i].item.isAlive = false;
                }
            }

            exr.AcquireMembers(slots2[i].item, i, result);
        }

        exr.SetResult(result);

        ClearAllSlot();
    }
}
