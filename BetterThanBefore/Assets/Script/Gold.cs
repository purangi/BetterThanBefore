using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    private Text GoldText; //�ؽ�Ʈ ��ü�� ã�Ƽ� ������ ����
    private int MyGold; // ���� ��尡 ������ ��Ÿ���ִ� ����
    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        GoldText = GameObject.Find("Gold").GetComponent<Text>();
        obj = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(obj == null)
        {
            MyGold = 7000;
        } else
        {
            MyGold = GameManager.instance.playerGold;

        }
        GoldText.text = MyGold.ToString() + " G";
    }
}

