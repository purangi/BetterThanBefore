using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yarn.Unity;

public class CommonerEmploy : MonoBehaviour
{
    public GameObject employ;
    public GameObject goldText;
    [SerializeField]
    private TextMeshProUGUI numberText; //텍스트 객체를 찾아서 저장할 변수 goldEmploy

    [SerializeField]
    private ExploreBuild exBuild;
    [SerializeField]
    private Item commoners;

    private int state; //gold = 0, atmos = 1;
    private int commonerNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void plazaDialogue()
    {
        GameManager.instance.ObjectClicked("PlazaDialogue");
    }

    [YarnCommand("commoner_employ")]
    public void commonerEmploy(int num)
    {
        employ.SetActive(true);
        state = num;
        if (state == 0)
        {
            goldText.SetActive(true);
        }
        else
        {
            goldText.SetActive(false);
        }
    }

    public void IncreaseCommoner()
    {
        if(state == 0)
        {
            if ((commonerNum + 1) * 500 <= GameManager.instance.playerGold)
            {
                commonerNum++;
            }
        } else
        {
            commonerNum++;
        }
        setNum(commonerNum);
    }

    public void DecreaseCommoner()
    {
        if (commonerNum >= 1)
        {
            commonerNum--;
        }
        else
        {
            commonerNum = 0;
        }
        setNum(commonerNum);
    }

    public void exitEmploy()
    {
        setNum(0);
        employ.SetActive(false);
    }

    private void setNum(int num)
    {
        commonerNum = num;
        numberText.text = num.ToString();
        int gold = num * 500;
        goldText.GetComponent<TextMeshProUGUI>().text = gold.ToString() + "G";
    }

    public void Employ()
    {
        if(state == 0)
        {
            deGoldEmploy();
        } else
        {
            deAtmosEmploy();
        }
        setNum(0);
        employ.SetActive(false);
    }

    //평민 골드 고용
    private void deGoldEmploy()
    {
        //ExploreBuild ex = GameObject.Find("ExploreBuild").GetComponent<ExploreBuild>();
        //Item commoner = GameObject.Find("Commoners").GetComponent<ItemPickUp>().item;

        if (GameManager.instance.playerGold - 500 * commonerNum >= 0)
        {
            GameManager.instance.playerGold -= 500 * commonerNum;
            exBuild.AcquireCharacter(commoners, commonerNum);
            GameManager.instance.employCommoner += commonerNum;
        }
        else
        {
            //고용 실패 -> 아예 막아뒀음
            /*
            isCurrentConversation = true;
            GameObject obj = GameObject.Find("Canvas").transform.Find("Dialogue").gameObject;
            DialogueRunner dlg = obj.transform.Find("DialogueRunner").GetComponent<DialogueRunner>();
            dlg.StartDialogue("EmployFail"); */
        }
    }

    //평민 협박 고용
    private void deAtmosEmploy()
    {
        //ExploreBuild ex = GameObject.Find("ExploreBuild").GetComponent<ExploreBuild>();
        //Item commoner = GameObject.Find("Commoners").GetComponent<ItemPickUp>().item;

        GameManager.instance.townAtmosphere += 5 * GameManager.instance.employCommoner;
        exBuild.AcquireCharacter(commoners, commonerNum);
        GameManager.instance.employCommoner += commonerNum;
    }
}
