using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class HouseClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image FirstImage; //기존 이미지

    public GameObject popup;
    public TextMeshProUGUI m_TypingText;

    public Sprite nextImage; //변경 테두리 이미지
    public Sprite cantImage; // 입장 불가 이미지
    public Sprite basicImage; //기본 테두리 이미지
    public string sceneName; //씬 이름

    private int visitedCheck;
    private int visitingGold;
    private bool weakness;

    // Start is called before the first frame update
    void Start()
    {
        FirstImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        //gm = GameObject.Find("GameManager");
        //DontDestroyOnLoad(gm);
    }

    void SetVisiting()
    {
        if (sceneName == "KnightHScene")
        {
            visitedCheck = GameManager.instance.KnightVisited;
            visitingGold = 1500;
            weakness = GameManager.instance.haveDismissal;
        }
        else if (sceneName == "MercenaryHScene")
        {
            visitedCheck = GameManager.instance.MercenaryVisited;
            visitingGold = 2500;
            weakness = GameManager.instance.haveWanted;
        }
        else if (sceneName == "AlchemHScene")
        {
            visitedCheck = GameManager.instance.AlchemVisited;
            visitingGold = 2500;
            weakness = GameManager.instance.haveRock;
        }
        else if (sceneName == "AcrobatHScene")
        {
            visitedCheck = GameManager.instance.AcrobatVisited;
            visitingGold = 2000;
            weakness = GameManager.instance.haveDrug;
        }
        else
        {
            visitedCheck = 6;
            visitingGold = 0;
            weakness = false;
        }
    }

    public void ChangeImage()
    {
        SetVisiting();

        if(/*!GameManager.instance.TodayVisited && */(GameManager.instance.playerGold > visitingGold))
        {
            if(visitedCheck == 1 && weakness)
            {
                FirstImage.sprite = cantImage;
            } else
            {
                FirstImage.sprite = nextImage;
            }
        } else
        {
            FirstImage.sprite = cantImage;
        }
    }

    public void BasicImage()
    {
        FirstImage.sprite = basicImage; //마우스 나갔을때
    }

    public void LoadScene() //버튼 클릭 시 화면 전환
    {
        SetVisiting();

        if (visitedCheck == 0 /* && GameManager.instance.TodayVisited */)
        {
            OpenPOPUP("하루에 한 곳만 방문할 수 있습니다.");
        }
        else if (visitedCheck == 1) //이미 고용한 상태
        {
            if(!weakness)
            {
                OpenPOPUP("인재가 영지를 떠났습니다.");
            } 
            //Talent로 구현할거라 바꿔야됨
            /*else if(GameManager.instance.TodayVisited)
            {
                OpenPOPUP("이미 고용 중인 인재입니다.");
            } */
            else
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        else if (visitedCheck == 2 && GameManager.instance.playerGold < visitingGold)
        {
            OpenPOPUP("골드가 충분하지 않습니다.");
        }
        else if (visitedCheck == 3)
        {
            OpenPOPUP("인재가 영지를 떠났습니다.");
        } else if(visitedCheck == 4)
        {
            OpenPOPUP("이미 고용 중인 인재입니다.");
        }
        else if (visitedCheck == 5)
        {
            OpenPOPUP("인재가 세상을 떠났습니다.");
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void InvenOpen() //인벤토리 오픈
    {
        GameObject inven = GameObject.Find("Inventory");
        if(inven != null)
        {
            GameObject obj = inven.transform.Find("go_InventoryBase").gameObject;
            obj.SetActive(true);
        }
    }

    public void InvenClose()
    {
        GameObject inven = GameObject.Find("Inventory");
        if (inven != null)
        {
            GameObject obj = inven.transform.Find("go_InventoryBase").gameObject;
            obj.SetActive(false);
        }
    }

    public void OpenPOPUP(string message)
    {
        popup.SetActive(true);
        StartCoroutine(Typing(m_TypingText, message, 0.1f));
    }

    IEnumerator Typing(TextMeshProUGUI typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeImage();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        BasicImage();
    }
}
