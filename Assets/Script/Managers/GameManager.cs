using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GameManager : SingletoneBase<GameManager>
{
    public int playerGold;
    public int townAtmosphere;
    public int townDead;

    /*
    public bool haveDismissal; //해임서 들고 있음
    public bool haveWanted;
    public bool haveRock;
    public bool haveDrug;

    public bool employKnight;
    public bool employMercenary;
    public bool employAcrobat;
    public bool employAlchem;

    public int KnightVisited;
    public int MercenaryVisited;
    public int AcrobatVisited;
    public int AlchemVisited; */

    //방문 여부 0 -> 첫방문 / 1 -> 고용 후 재방문 / 2 -> 골드부족으로 미고용 후 재방문
    // 3 -> 방문 불가 / 4 -> 재고용됨 / 5 -> 사망함
    // 이중에 5는 Die로 분리 가능
    //1,2의 경우는 다 방 Class 만들어서 하면 따로 구분 가능할듯?
    public List<Talent> talents;

    public int employCommoner;

    public int getClues;

    public int Days;

    public bool eventAcrobat;
    public bool eventAlchem;

    private DialogueRunner dlg;

    bool interactable = true;

    void Awake()
    {
        isDontDestroy = true; //방 왕복할때 true 필요
    }

    public void CreateTalents() //0 기사 1 용병 2 곡예사 3 연금술사
    {
        //저장 파일 없다면 추가
        talents.Add(new Talent("기사", JobType.Knight));
        talents.Add(new Talent("용병", JobType.Mercenary));
        talents.Add(new Talent("곡예사", JobType.Acrobat));
        talents.Add(new Talent("연금술사", JobType.Alchem));
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
            if (tlt.isVisited == true)
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
