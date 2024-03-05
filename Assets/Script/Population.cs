using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Population : MonoBehaviour
{
    private Text DeadText; //텍스트 객체를 찾아서 저장할 변수
    private int dead; // 직접 사망자가 얼마인지 나타내주는 변수

    // Start is called before the first frame update
    void Start()
    {
        DeadText = GameObject.Find("Population").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        dead = GameManager.Instance.townDead;
        DeadText.text = dead.ToString();
    }

    public void increasePopulation(int num)
    {
        dead += num;
    }

    public void decreasePopulation(int num) // 골드 감소
    {
        dead -= num;
    }
}
