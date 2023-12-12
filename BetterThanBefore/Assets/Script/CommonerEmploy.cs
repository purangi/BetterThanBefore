using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommonerEmploy : MonoBehaviour
{
    private TextMeshProUGUI numberText; //�ؽ�Ʈ ��ü�� ã�Ƽ� ������ ���� goldEmploy
    private TextMeshProUGUI numberText2; //atmosEmploy
    private int commonerNumber; // ���� ���õ� ��� �� ������ ��Ÿ���ִ� ����
    private GameObject obj;

    public string state;

    // Start is called before the first frame update
    void Start()
    {
        GameObject base1 = GameObject.Find("Canvas").transform.Find("GoldEmploy").gameObject;
        numberText = base1.transform.Find("CommonerNumber").GetComponent<TextMeshProUGUI>();
        GameObject base2 = GameObject.Find("Canvas").transform.Find("AtmosEmploy").gameObject;
        numberText2 = base2.transform.Find("CommonerNumber").GetComponent<TextMeshProUGUI>();
        obj = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (obj == null)
        {
            commonerNumber = 0;
        }
        else
        {
            commonerNumber = GameManager.instance.showCommoner;

        }
        numberText.text = commonerNumber.ToString();
        numberText2.text = commonerNumber.ToString();
    }

    public void IncreaseCommoner()
    {
        if(state == "Gold")
        {
            if ((GameManager.instance.showCommoner + 1) * 500 <= GameManager.instance.playerGold)
            {
                GameManager.instance.showCommoner += 1;
            }
        } else
        {
            GameManager.instance.showCommoner += 1;
        }
    }

    public void DecreaseCommoner()
    {
        if (GameManager.instance.showCommoner >= 1)
        {
            GameManager.instance.showCommoner -= 1;
        }
        else
        {
            GameManager.instance.showCommoner = 0;
        }
    }
}
