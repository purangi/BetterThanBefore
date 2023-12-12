using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmployGoldText : MonoBehaviour
{
    private TextMeshProUGUI goldText; //�ؽ�Ʈ ��ü�� ã�Ƽ� ������ ����
    private int goldNumber; // ���� ��尡 ������ ��Ÿ���ִ� ����
    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        GameObject basic = GameObject.Find("Canvas").transform.Find("GoldEmploy").gameObject;
        goldText = basic.transform.Find("GoldText").GetComponent<TextMeshProUGUI>();
        obj = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (obj == null)
        {
            goldNumber = 0;
        }
        else
        {
            goldNumber = GameManager.instance.showCommoner * 500;
        }
        goldText.text = goldNumber.ToString();
    }
}
