using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    private Text GoldText; //텍스트 객체를 찾아서 저장할 변수
    private int MyGold; // 직접 골드가 얼마인지 나타내주는 변수
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

