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
    private GameObject go_InventoryBase; // Inventory_Base 이미지
    [SerializeField]
    private GameObject go_SlotsParent;  // Slot들의 부모인 Grid Setting
    [SerializeField]
    private GameObject go_SlotsParent2;  // Slot들의 부모인 Grid Setting
    [SerializeField] private Sprite[] clueImages;
    [SerializeField] private GameObject[] clueObj;
    [SerializeField]
    private TextMeshProUGUI result_text; // 성공 여부 텍스트
    [SerializeField]
    private TextMeshProUGUI day_text; // 날짜 텍스트
    [SerializeField]
    private GameObject Clue; // 단서 획득

    private ResultSlot[] slots;  // 슬롯들 배열
    private ResultSlot[] slots2;  // 슬롯들 배열

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
        if(success == "성공")
        {
            result_text.text = "탐사 성공";
            ResultSlot clues = Clue.GetComponent<ResultSlot>();
            Inventory inven = GameObject.Find("Inventory").GetComponent<Inventory>();

            inven.AcquireItem(clueObj[GameManager.instance.getClues].transform.GetComponent<ItemPickUp>().item);

            clues.itemImage.sprite = clueImages[GameManager.instance.getClues];
            GameManager.instance.getClues += 1;
            GameManager.instance.townAtmosphere -= 10;
            clues.AddResult("단서 획득 <color=red>" + GameManager.instance.getClues + "</color> / 5");
            
        } else if(success == "실패")
        {
            result_text.text = "탐사 실패";
            ResultSlot clues = Clue.GetComponent<ResultSlot>();
            GameManager.instance.townAtmosphere += 10;
            clues.AddResult("단서 미획득 " + GameManager.instance.getClues + "/ 5");
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
            returnText = "기사가 랜덤 한 명을 보호를 <color=red>성공</color>했습니다.";
        }

        if (item.isAlive)
        {
            if (item.itemName == "Mercenary")
            {
                int gold = Random.Range(5, 11) * 500;
                GameManager.instance.playerGold += gold;

                returnText = "용병이 <color=red>생환</color>하여 <color=red>" + gold.ToString() + "G</color>를 가져왔습니다.";
            } else if(item.itemName == "Acrobat")
            {
                GameManager.instance.eventAcrobat = true;
                returnText = "곡예사가 <color=red>생환</color>하여 축제 이벤트 발생에 <color=red>성공</color>했습니다.";
            }
            else if (item.itemName == "Alchem")
            {
                if(result == "성공")
                {
                    GameManager.instance.eventAlchem = true;
                    returnText = "연금술사가 <color=red>탐사 성공</color>하여 농지 이벤트 발생에 <color=red>성공</color>했습니다.";
                }
            }
            else
            {
            }
        } else
        {
            /* // TODO: 고용 수정
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
                Debug.Log("평민 죽음");
            } */

            GameManager.instance.townDead += 1;
        }

        return returnText;
    }

    private void EmployTalents(Item item) //재고용 설계 필요
    {
        /* //TODO : 재고용 설계
        if(item.itemName == "Knight")
        {
            if(GameManager.instance.KnightVisited != 4) //재고용일때는 안변함
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

        //day 넘기는거 GameManager로 구현 예정
        GameManager.instance.Days += 1;

        if (GameManager.instance.Days == 1)
        {
            day_text.text = "첫째 날";
        }
        else if (GameManager.instance.Days == 2)
        {
            day_text.text = "둘째 날";
        }
        else if (GameManager.instance.Days == 3)
        {
            day_text.text = "셋째 날";
        }
        else if (GameManager.instance.Days == 4)
        {
            day_text.text = "넷째 날";
        }
        else if (GameManager.instance.Days == 5)
        {
            day_text.text = "다섯째 날";
        }
        else if (GameManager.instance.Days == 6)
        {
            day_text.text = "여섯째 날";
        }
        else if (GameManager.instance.Days == 7)
        {
            day_text.text = "일곱째 날";
        }
        else if (GameManager.instance.Days == 8)
        {
            day_text.text = "여덟째 날";
        }
        else if (GameManager.instance.Days == 9)
        {
            day_text.text = "아홉째 날";
        }
        else if (GameManager.instance.Days == 10)
        {
            day_text.text = "열째 날";
        } else if(GameManager.instance.Days >= 11)
        {
            day_text.text = "동굴에서 소리가 들려온다···";
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
        //여기서 구현 안할거임
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
