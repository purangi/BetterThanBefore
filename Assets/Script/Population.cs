using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Population : MonoBehaviour
{
    private Text DeadText; //�ؽ�Ʈ ��ü�� ã�Ƽ� ������ ����
    private int dead; // ���� ����ڰ� ������ ��Ÿ���ִ� ����

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

    public void decreasePopulation(int num) // ��� ����
    {
        dead -= num;
    }
}
