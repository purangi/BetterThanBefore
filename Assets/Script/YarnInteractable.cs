using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using TMPro;
using UnityEngine.SceneManagement;

public class YarnInteractable : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    private DialogueRunner dlg;
    public string conversationStartNode;

    //private float time_start;
    //private float time_current;

    private bool isCurrentConversation;
    private bool interactable = true; // whether this character should be enabled right now
                                      // (begins true, but may not always be true)
    bool IsExploreAble;

    public Sprite sprExpand; //커진 sprite
    public Sprite sprOrigin; //원래 sprite

    public Sprite DespairImage;

    public bool RoomExplore
    {
        get { return IsExploreAble; }
        set { IsExploreAble = value; }
    }

    // Start is called before the first frame update
    public void Start()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        //summaryRunner = GameObject.Find("SummaryRunner").GetComponent<Yarn.Unity.DialogueRunner>();
        //time_start = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // run dialogue from {conversationStartNode}
    private void StartConversation()
    {
        isCurrentConversation = true;
        dialogueRunner.StartDialogue(conversationStartNode);
    }
    /*
    private void StartSummary()
    {
        isCurrentConversation = true;
        summaryRunner.StartDialogue(conversationStartNode);
    } */

    // reverse StartConversation's changes: 
    // re-enable scene interaction, deactivate indicator, etc.
    private void EndConversation()
    {
        if (isCurrentConversation)
        {
            // TODO *stop animation or turn off indicator or whatever* HERE
            isCurrentConversation = false;
        }
    }

    // make character not able to be clicked on
    //public void DisableConversation();
    /* // GameManager로 이동
    public void ObjectClicked(string node)
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("Dialogue").gameObject;
        dlg = obj.transform.Find("DialogueRunner").GetComponent<DialogueRunner>();

        // if this character is enabled and no conversation is already running
        if (interactable && !dlg.IsDialogueRunning)
        {
            // then run this character's conversation
            dlg.StartDialogue(node);
        }
    }*/

    [YarnCommand("end_dialogue")]
    public void EndDialogue()
    {
        if (interactable && dialogueRunner.IsDialogueRunning)
        {
            EndConversation();
        }
    }

    public void ArmorClickExpand()
    {
        GameObject obj = GameObject.Find("KHArmor");
        RectTransform rectTran = obj.GetComponent<RectTransform>();
        Vector3 position = obj.transform.localPosition;

        if (interactable && !dialogueRunner.IsDialogueRunning)
        {
            // then run this character's conversation
            StartConversation();
            if (IsExploreAble == true)
            {
                obj.GetComponent<Image>().sprite = sprExpand;
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 471);
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 651);
                position.x = 0;
                position.y = -52;
                obj.transform.localPosition = position;
            }
        }

    }

    [YarnCommand("armor_origin")]
    public void ArmorOrigin()
    {
        GameObject obj = GameObject.Find("KHArmor");
        RectTransform rectTran = obj.GetComponent<RectTransform>();
        Vector3 position = obj.transform.localPosition;

        obj.GetComponent<Image>().sprite = sprOrigin;
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 156);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 374);
        position.x = 259;
        position.y = -101;
        obj.transform.localPosition = position;
    }

    public void DollClickExpand()
    {
        GameObject obj = GameObject.Find("KHDoll");

        RectTransform rectTran = obj.GetComponent<RectTransform>();
        Vector3 position = obj.transform.localPosition;

        if (interactable && !dialogueRunner.IsDialogueRunning)
        {
            // then run this character's conversation
            StartConversation();
            if (IsExploreAble == true)
            {
                obj.GetComponent<Image>().sprite = sprExpand;
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 512);
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 483);
                position.x = 0;
                position.y = 0;
                obj.transform.localPosition = position;
            }
        }
    }

    [YarnCommand("doll_origin")]
    public void DollOrigin()
    {
        GameObject obj = GameObject.Find("KHDoll");
        RectTransform rectTran = obj.GetComponent<RectTransform>();
        Vector3 position = obj.transform.localPosition;

        obj.GetComponent<Image>().sprite = sprOrigin;
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 92);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 123);
        position.x = 425;
        position.y = 153;
        obj.transform.localPosition = position;
    }

    [YarnCommand("fade_wait")]
    static IEnumerator FadeWait()
    {
        yield return new WaitForSeconds(2.4f);
    }

    [YarnCommand("fade_out")]
    public IEnumerator FadeOut()
    {
        GameObject obj = GameObject.Find("BlackLayer");
        obj.transform.SetAsLastSibling();
        Image Fade = obj.GetComponent<Image>();

        for (float f = 0f; f <= 1.0f; f += 0.01f)
        {
            Color c = Fade.color;
            c.a = f;
            Fade.color = c;
            yield return null;
        }

        StartCoroutine("WaitForIt");
    }

    public IEnumerator StartExploreFade()
    {
        GameObject obj = GameObject.Find("StartExplore");
        if(obj != null)
        {
            Image Fade = obj.GetComponent<Image>();
            Debug.Log("실행");

            for (float f = 0.55f; f >= 0; f -= 0.01f)
            {
                Color c = Fade.color;
                c.a = f;
                Fade.color = c;
                yield return null;
            }

            StartCoroutine("WaitForStart");
        }
    }

    IEnumerator WaitForIt()
    {
        GameObject obj = GameObject.Find("BlackLayer");
        Image Fade = obj.GetComponent<Image>();
        Fade.color = Color.white;
        yield return new WaitForSeconds(2.0f);
        obj.SetActive(false);
    }

    IEnumerator WaitForStart()
    {
        GameObject obj = GameObject.Find("StartExplore");
        Image Fade = obj.GetComponent<Image>();
        yield return new WaitForSeconds(1.1f);
        obj.SetActive(false);
    }

    [YarnCommand("set_result")]
    public void SetResult(string resultText, string summaryText)
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("EmployResult").gameObject;
        //GameObject obj = GameObject.Find("EmployResult");
        obj.SetActive(true);

        TextMeshProUGUI Result = obj.transform.Find("ResultText").gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI Summary = obj.transform.Find("SummaryText").gameObject.GetComponent<TextMeshProUGUI>();
        summaryText = summaryText.Replace("_", " ");
        summaryText = summaryText.Replace("+", "\n");

        if (resultText == "성공")
        {
            Result.text = "<color=#FFFFFF>고용 성공</color>";
            Summary.text = "능력 \n" + summaryText;
        } else if (resultText == "실패")
        {
            Result.text = "고용 " + resultText;
            Summary.text = summaryText;
        } else if (resultText == "재고용")
        {
            Result.text = "<color=#FF8000>재고용 완료</color>";
            Summary.text = "";
        }

        StartCoroutine(CustomWait());
    }

    [YarnCommand("employ_talents")]
    public void EmployTalents(string talent)
    {
        if (talent == "기사")
        {
            GameManager.instance.employKnight = true;
        } else if (talent == "용병")
        {
            GameManager.instance.employMercenary = true;
        } else if (talent == "곡예사")
        {
            GameManager.instance.employAcrobat = true;
        } else if (talent == "연금술사")
        {
            GameManager.instance.employAlchem = true;
        }
    }

    IEnumerator CustomWait()
    {
        yield return new WaitForSeconds(5.0f);

        SceneManager.LoadScene("MainScene");
    }

    [YarnCommand("delete_character")]
    public void DeleteCharacter()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("Dialogue").gameObject;
        Image charImage = obj.transform.Find("CharacterImage").gameObject.GetComponent<Image>();
        Color c = charImage.color;
        c.a = 0f;
        charImage.color = c;
    }

    [YarnCommand("return_character")]
    public void ReturnCharacter()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("Dialogue").gameObject;
        Image charImage = obj.transform.Find("CharacterImage").gameObject.GetComponent<Image>();

        Color c = charImage.color;
        c.a = 1f;
        charImage.color = c;
    }

    [YarnCommand("change_despair")]
    public void ChangeDespair()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("Dialogue").gameObject;
        Image charImage = obj.transform.Find("CharacterImage").gameObject.GetComponent<Image>();

        charImage.sprite = DespairImage;
    }

    [YarnCommand("finish_master")]
    public void FinishMaster()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("MHMasterExpand").gameObject;
        obj.SetActive(false);
    }

    [YarnCommand("finish_gambler")]
    public void FinishGambler()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("MHGamblerExpand").gameObject;
        obj.SetActive(false);
    }

    [YarnCommand("finish_table")]
    public void FinishTable()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("MHTableExpand").gameObject;
        obj.SetActive(false);
    }

    [YarnCommand("finish_monkey")]
    public void FinishMonkey()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("BHMonkeyExpand").gameObject;
        obj.SetActive(false);
    }

    [YarnCommand("finish_circus")]
    public void FinishCircus()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("BHCircusExpand").gameObject;
        obj.SetActive(false);
    }

    [YarnCommand("finish_book")]
    public void FinishBook()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("AHBookExpand").gameObject;
        obj.SetActive(false);
    }
    [YarnCommand("finish_desk")]
    public void FinishDesk()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("AHDeskExpand").gameObject;
        obj.SetActive(false);
    }
    [YarnCommand("finish_tortures")]
    public void FinishTortures()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("AHTortures").gameObject;
        obj.SetActive(false);
    }

    [YarnCommand("start_finding")]
    public void StartFinding()
    {
        StartCoroutine("StartExploreFade");

        GameObject back = GameObject.Find("Canvas").transform.Find("BackButton").gameObject;
        back.SetActive(true);
    }

    [YarnCommand("show_weakness")]
    public void ShowWeakness(string weakness)
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("ShowWeakness").gameObject;
        if(weakness == "기사")
        {
            GameManager.instance.haveDismissal = false;
        } else if(weakness == "용병")
        {
            GameManager.instance.haveWanted = false;
        } else if(weakness == "곡예사")
        {
            GameManager.instance.haveDrug = false;
        } else if(weakness == "연금술사")
        {
            GameManager.instance.haveRock = false;
        }
        obj.SetActive(true);
    }

    [YarnCommand("decrease_gold")]
    public void DecreaseGold(string type)
    {
        if(type == "평민")
        {
            GameManager.instance.playerGold -= 500 * GameManager.instance.employCommoner;
        } else if(type == "기사")
        {
            GameObject obj = GameObject.Find("Canvas").transform.Find("EmployResult").gameObject;
            GameObject text = obj.transform.Find("GoldUseText").gameObject;

            text.SetActive(true);

            GameManager.instance.playerGold -= 1500;
        } else if(type == "용병")
        {
            GameObject obj = GameObject.Find("Canvas").transform.Find("EmployResult").gameObject;
            GameObject text = obj.transform.Find("GoldUseText").gameObject;

            text.SetActive(true);

            GameManager.instance.playerGold -= 2500;
        }
        else if (type == "연금술사")
        {
            GameObject obj = GameObject.Find("Canvas").transform.Find("EmployResult").gameObject;
            GameObject text = obj.transform.Find("GoldUseText").gameObject;

            text.SetActive(true);

            GameManager.instance.playerGold -= 2500;
        }
        else if (type == "곡예사")
        {
            GameObject obj = GameObject.Find("Canvas").transform.Find("EmployResult").gameObject;
            GameObject text = obj.transform.Find("GoldUseText").gameObject;

            text.SetActive(true);

            GameManager.instance.playerGold -= 2000;
        }
    } 

    [YarnCommand("increase_gold")]
    public void IncreaseGold(int amount)
    {
        GameManager.instance.playerGold += amount;
    }

    [YarnCommand("increase_atmos")]
    public void IncreaseAtmos(int num)
    {
        GameManager.instance.townAtmosphere += num;
    }

    [YarnCommand("set_visited")]
    public void SetVisited(string talent, int num)
    {
        if(num != 2)
        {
            GameManager.instance.TodayVisited = true;
        }

        if (talent == "기사")
        {
            GameManager.instance.KnightVisited = num;
        }
        else if (talent == "용병")
        {
            GameManager.instance.MercenaryVisited = num;
        }
        else if (talent == "연금술사")
        {
            GameManager.instance.AlchemVisited = num;
        }
        else if (talent == "곡예사")
        {
            GameManager.instance.AcrobatVisited = num;
        }
    }
}
