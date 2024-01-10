using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class HouseClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image FirstImage; //���� �̹���

    public GameObject popup;
    public TextMeshProUGUI m_TypingText;

    public Sprite nextImage; //���� �׵θ� �̹���
    public Sprite cantImage; // ���� �Ұ� �̹���
    public Sprite basicImage; //�⺻ �׵θ� �̹���
    public string sceneName; //�� �̸�

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
        FirstImage.sprite = basicImage; //���콺 ��������
    }

    public void LoadScene() //��ư Ŭ�� �� ȭ�� ��ȯ
    {
        SetVisiting();

        if (visitedCheck == 0 /* && GameManager.instance.TodayVisited */)
        {
            OpenPOPUP("�Ϸ翡 �� ���� �湮�� �� �ֽ��ϴ�.");
        }
        else if (visitedCheck == 1) //�̹� ����� ����
        {
            if(!weakness)
            {
                OpenPOPUP("���簡 ������ �������ϴ�.");
            } 
            //Talent�� �����ҰŶ� �ٲ�ߵ�
            /*else if(GameManager.instance.TodayVisited)
            {
                OpenPOPUP("�̹� ��� ���� �����Դϴ�.");
            } */
            else
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        else if (visitedCheck == 2 && GameManager.instance.playerGold < visitingGold)
        {
            OpenPOPUP("��尡 ������� �ʽ��ϴ�.");
        }
        else if (visitedCheck == 3)
        {
            OpenPOPUP("���簡 ������ �������ϴ�.");
        } else if(visitedCheck == 4)
        {
            OpenPOPUP("�̹� ��� ���� �����Դϴ�.");
        }
        else if (visitedCheck == 5)
        {
            OpenPOPUP("���簡 ������ �������ϴ�.");
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void InvenOpen() //�κ��丮 ����
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
