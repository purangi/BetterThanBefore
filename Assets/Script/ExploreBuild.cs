using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ExploreBuild : MonoBehaviour
{
    public static bool inventoryActivated = false;
    private DialogueRunner dialogueRunner;

    [SerializeField]
    private GameObject go_InventoryBase; // Inventory_Base 이미지
    [SerializeField]
    private GameObject go_SlotsParent;  // Slot들의 부모인 Grid Setting
    [SerializeField]
    private GameObject go_SlotsParent2;  // Slot들의 부모인 Grid Setting
    [SerializeField] private Item[] items;
    private Slot[] slots;  // 슬롯들 배열
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

    public void BuildExplorer(Item _item, int _count) //나중에 코드 수정
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
            if(slots2[i].item != null) //null인 것이 발견되면 버튼 안눌리도록 설계
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

        if(canStart) //결과 출력
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
        } else //탐사대를 꾸리라고 출력
        {
            Debug.Log("탐사대를 꾸리세요");
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
                        Debug.Log("기사가 살린 애가 아닌데 산 경우");
                        slots2[i].item.isAlive = true;
                    }
                    else
                    {
                        Debug.Log("기사가 살린 애가 아닌데 죽은 경우");
                        slots2[i].item.isAlive = false;
                    }
                }
                else
                {
                    slots2[i].item.isAlive = true;
                    Debug.Log("기사가 살린 애인 경우" + i + "살림");
                }
            } else
            {
                Debug.Log("기사가 없을 경우");
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
