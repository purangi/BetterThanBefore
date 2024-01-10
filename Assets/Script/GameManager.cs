using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int playerGold;
    public int townAtmosphere;
    public int townDead;

    public bool haveDismissal; //해임서 들고 있음
    public bool haveWanted;
    public bool haveRock;
    public bool haveDrug;

    public bool employKnight;
    public bool employMercenary;
    public bool employAcrobat;
    public bool employAlchem;

    //방문 여부 0 -> 첫방문 / 1 -> 고용 후 재방문 / 2 -> 골드부족으로 미고용 후 재방문
    // 3 -> 방문 불가 / 4 -> 재고용됨 / 5 -> 사망함
    public int KnightVisited; 
    public int MercenaryVisited;
    public int AcrobatVisited;
    public int AlchemVisited;

    public List<Talent> talents;

    public int employCommoner;
    //public int showCommoner;

    public int getClues;

    public int Days;

    public bool eventAcrobat;
    public bool eventAlchem;

    private DialogueRunner dlg;

    bool interactable = true;

    void Start()
    {
        //GameObject inven = GameObject.Find("go_InventoryBase");
        //inven.SetActive(false);
    }

    void Awake()
    { 
        instance = this;
    }

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
    }

    public bool TodayVisited()
    {
        bool todayVisited = false;

        foreach (Talent tlt in talents)
        {
            if (tlt.IsVisited == true)
            {
                todayVisited = true;
            }
        }

        return todayVisited;
    }

    public void NextDay()
    {

    }
}
