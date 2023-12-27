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

    public bool haveDismissal; //���Ӽ� ��� ����
    public bool haveWanted;
    public bool haveRock;
    public bool haveDrug;

    public bool employKnight;
    public bool employMercenary;
    public bool employAcrobat;
    public bool employAlchem;

    //�湮 ���� 0 -> ù�湮 / 1 -> ��� �� ��湮 / 2 -> ���������� �̰�� �� ��湮
    // 3 -> �湮 �Ұ� / 4 -> ����� / 5 -> �����
    public int KnightVisited; 
    public int MercenaryVisited;
    public int AcrobatVisited;
    public int AlchemVisited;

    public List<Talent> talents;

    public int employCommoner;
    //public int showCommoner;

    public int getClues;

    public int Days;

    public bool TodayVisited;

    public bool eventAcrobat;
    public bool eventAlchem;

    private DialogueRunner dlg;

    void Start()
    {
        //GameObject inven = GameObject.Find("go_InventoryBase");
        //inven.SetActive(false);
    }

    void Awake()
    { 
        instance = this;
    }

    public void ObjectClicked(string node, bool interactable)
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
}
