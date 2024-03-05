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
    public bool haveDismissal; //���Ӽ� ��� ����
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

    //�湮 ���� 0 -> ù�湮 / 1 -> ��� �� ��湮 / 2 -> ���������� �̰�� �� ��湮
    // 3 -> �湮 �Ұ� / 4 -> ����� / 5 -> �����
    // ���߿� 5�� Die�� �и� ����
    //1,2�� ���� �� �� Class ���� �ϸ� ���� ���� �����ҵ�?
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
        isDontDestroy = true; //�� �պ��Ҷ� true �ʿ�
    }

    public void CreateTalents() //0 ��� 1 �뺴 2 ��� 3 ���ݼ���
    {
        //���� ���� ���ٸ� �߰�
        talents.Add(new Talent("���", JobType.Knight));
        talents.Add(new Talent("�뺴", JobType.Mercenary));
        talents.Add(new Talent("���", JobType.Acrobat));
        talents.Add(new Talent("���ݼ���", JobType.Alchem));
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
