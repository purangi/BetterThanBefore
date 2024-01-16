using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ExploreResult : MonoBehaviour
{
    public static bool inventoryActivated = false;

    [SerializeField]
    private GameObject go_InventoryBase; // Inventory_Base �̹���
    [SerializeField]
    private GameObject go_SlotsParent;  // Slot���� �θ��� Grid Setting
    [SerializeField]
    private GameObject go_SlotsParent2;  // Slot���� �θ��� Grid Setting
    [SerializeField] private Sprite[] clueImages;
    [SerializeField] private GameObject[] clueObj;
    [SerializeField]
    private TextMeshProUGUI result_text; // ���� ���� �ؽ�Ʈ
    [SerializeField]
    private TextMeshProUGUI day_text; // ��¥ �ؽ�Ʈ
    [SerializeField]
    private GameObject Clue; // �ܼ� ȹ��

    private ResultSlot[] slots;  // ���Ե� �迭
    private ResultSlot[] slots2;  // ���Ե� �迭

    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<ResultSlot>();
        slots2 = go_SlotsParent2.GetComponentsInChildren<ResultSlot>();
    }

    void Update()
    {

    }

    public void SetResult(string success)
    {
        if(success == "����")
        {
            result_text.text = "Ž�� ����";
            ResultSlot clues = Clue.GetComponent<ResultSlot>();
            Inventory inven = GameObject.Find("Inventory").GetComponent<Inventory>();

            inven.AcquireItem(clueObj[GameManager.instance.getClues].transform.GetComponent<ItemPickUp>().item);

            clues.itemImage.sprite = clueImages[GameManager.instance.getClues];
            GameManager.instance.getClues += 1;
            GameManager.instance.townAtmosphere -= 10;
            clues.AddResult("�ܼ� ȹ�� <color=red>" + GameManager.instance.getClues + "</color> / 5");
            
        } else if(success == "����")
        {
            result_text.text = "Ž�� ����";
            ResultSlot clues = Clue.GetComponent<ResultSlot>();
            GameManager.instance.townAtmosphere += 10;
            clues.AddResult("�ܼ� ��ȹ�� " + GameManager.instance.getClues + "/ 5");
        }
    }

    public void OpenExplore()
    {
        go_InventoryBase.SetActive(true);
    }

    public void CloseExplore()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].ClearSlot();
        }
        for (int i = 0; i < slots2.Length; i++)
        {
            slots2[i].ClearText();
        }

        StartCoroutine("FadeOut");
        go_InventoryBase.SetActive(false);
    }

    public void AcquireMembers(Item _item, int i,string result)
    {
        GameObject obj = GameObject.Find("GameManager");

        if (obj != null)
        {
            slots[i].AddMembers(_item);
            EmployTalents(_item);
            for(int j = 0; j < slots2.Length; j++)
            {
                if(slots2[j].clue_text.text == "")
                {
                    slots2[j].AddResult(CheckItems(_item, result));
                    return;
                }
            }
        }
    }

    private string CheckItems(Item item, string result)
    {
        string returnText = "";

        if (item.itemName == "Knight")
        {
            returnText = "��簡 ���� �� ���� ��ȣ�� <color=red>����</color>�߽��ϴ�.";
        }

        if (item.isAlive)
        {
            if (item.itemName == "Mercenary")
            {
                int gold = Random.Range(5, 11) * 500;
                GameManager.instance.playerGold += gold;

                returnText = "�뺴�� <color=red>��ȯ</color>�Ͽ� <color=red>" + gold.ToString() + "G</color>�� �����Խ��ϴ�.";
            } else if(item.itemName == "Acrobat")
            {
                GameManager.instance.eventAcrobat = true;
                returnText = "��簡 <color=red>��ȯ</color>�Ͽ� ���� �̺�Ʈ �߻��� <color=red>����</color>�߽��ϴ�.";
            }
            else if (item.itemName == "Alchem")
            {
                if(result == "����")
                {
                    GameManager.instance.eventAlchem = true;
                    returnText = "���ݼ��簡 <color=red>Ž�� ����</color>�Ͽ� ���� �̺�Ʈ �߻��� <color=red>����</color>�߽��ϴ�.";
                }
            }
            else
            {
            }
        } else
        {
            /* // TODO: ��� ����
            if(item.itemName == "Knight")
            {
                GameManager.instance.KnightVisited = 5;
                GameManager.instance.employKnight = false;
            } else if(item.itemName == "Mercenary")
            {
                GameManager.instance.MercenaryVisited = 5;
                GameManager.instance.employMercenary = false;
            } else if(item.itemName == "Alchem")
            {
                GameManager.instance.AlchemVisited = 5;
                GameManager.instance.employAlchem = false;
            } else if(item.itemName == "Acrobat")
            {
                GameManager.instance.AcrobatVisited = 5;
                GameManager.instance.employAcrobat = false;
            } else
            {
                Debug.Log("��� ����");
            } */

            GameManager.instance.townDead += 1;
        }

        return returnText;
    }

    private void EmployTalents(Item item) //���� ���� �ʿ�
    {
        /* //TODO : ���� ����
        if(item.itemName == "Knight")
        {
            if(GameManager.instance.KnightVisited != 4) //�����϶��� �Ⱥ���
            {
                GameManager.instance.employKnight = false;
            }
            
        } else if(item.itemName == "Mercenary")
        {
            if (GameManager.instance.MercenaryVisited != 4)
            {
                GameManager.instance.employMercenary = false;
            }
        } else if (item.itemName == "Alchem")
        {
            if (GameManager.instance.MercenaryVisited != 4)
            {
                GameManager.instance.employAlchem = false;
            }
            
        } else if(item.itemName == "Acrobat")
        {
            if (GameManager.instance.MercenaryVisited != 4)
            {
                GameManager.instance.employAcrobat = false;
            }
            
        } */
    }

    public IEnumerator FadeOut()
    {
        GameObject obj = GameObject.Find("BlackLayer");
        obj.transform.SetAsLastSibling();
        Image Fade = obj.GetComponent<Image>();

        //day �ѱ�°� GameManager�� ���� ����
        GameManager.instance.Days += 1;

        if (GameManager.instance.Days == 1)
        {
            day_text.text = "ù° ��";
        }
        else if (GameManager.instance.Days == 2)
        {
            day_text.text = "��° ��";
        }
        else if (GameManager.instance.Days == 3)
        {
            day_text.text = "��° ��";
        }
        else if (GameManager.instance.Days == 4)
        {
            day_text.text = "��° ��";
        }
        else if (GameManager.instance.Days == 5)
        {
            day_text.text = "�ټ�° ��";
        }
        else if (GameManager.instance.Days == 6)
        {
            day_text.text = "����° ��";
        }
        else if (GameManager.instance.Days == 7)
        {
            day_text.text = "�ϰ�° ��";
        }
        else if (GameManager.instance.Days == 8)
        {
            day_text.text = "����° ��";
        }
        else if (GameManager.instance.Days == 9)
        {
            day_text.text = "��ȩ° ��";
        }
        else if (GameManager.instance.Days == 10)
        {
            day_text.text = "��° ��";
        } else if(GameManager.instance.Days >= 11)
        {
            day_text.text = "�������� �Ҹ��� ����´١�����";
        }

        for (float f = 0f; f <= 1.0f; f += 0.01f)
        {
            Color c = Fade.color;
            c.a = f;
            Fade.color = c;
            yield return null;
        }

        day_text.color = new Color32(255, 255, 255, 255);

        StartCoroutine("WaitForIt");
    }

    IEnumerator WaitForIt()
    {
        GameObject obj = GameObject.Find("BlackLayer");
        Image Fade = obj.GetComponent<Image>();
        yield return new WaitForSeconds(2.0f);
        Color c = Fade.color;
        c.a = 0f;
        Fade.color = c;
        day_text.color = new Color32(255, 255, 255, 0);
        //���⼭ ���� ���Ұ���
        //GameManager.instance.TodayVisited = false;
        obj.transform.SetAsFirstSibling();

        CheckEnding();
    }

    void CheckEnding()
    {
        if (GameManager.instance.Days >= 11)
        {
            if (GameManager.instance.getClues < 5)
                SceneManager.LoadScene("BadEnding");
        }
        else if (GameManager.instance.townDead >= 20)
        {
            SceneManager.LoadScene("BadEnding");
        }
        else if (GameManager.instance.getClues >= 5)
        {
            if (GameManager.instance.townAtmosphere > 50)
            {
                SceneManager.LoadScene("NormalEnding");
            }
            else
            {
                SceneManager.LoadScene("HappyEnding");
            }
        } else
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
