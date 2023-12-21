using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        //GameObject inven = GameObject.Find("go_InventoryBase");
        //inven.SetActive(false);
    }

    void Awake()
    { 
        instance = this;
    }
}
