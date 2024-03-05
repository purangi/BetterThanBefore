using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndingDays : MonoBehaviour
{
    public TextMeshProUGUI day_text;

    public Text HarEvent;
    public Text SacEvent;
    public Text AppEvent;
    public Text FirEvent;
    public Text AlchemEvent;

    // Start is called before the first frame update
    void Start()
    {
        CheckEnding();
        ShowDate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowDate()
    {
        if (GameManager.Instance.Days == 1)
        {
            day_text.text = "ù° ��";
            /*
            if(!GameManager.instance.TodayVisited)
            {
                ShowHow();
            }*/
        } else if(GameManager.Instance.Days == 2)
        {
            day_text.text = "��° ��";
        }
        else if (GameManager.Instance.Days == 3)
        {
            day_text.text = "��° ��";
        }
        else if (GameManager.Instance.Days == 4)
        {
            day_text.text = "��° ��";
        }
        else if (GameManager.Instance.Days == 5)
        {
            day_text.text = "�ټ�° ��";
        }
        else if (GameManager.Instance.Days == 6)
        {
            day_text.text = "����° ��";
        }
        else if (GameManager.Instance.Days == 7)
        {
            day_text.text = "�ϰ�° ��";
        }
        else if (GameManager.Instance.Days == 8)
        {
            day_text.text = "����° ��";
        }
        else if (GameManager.Instance.Days == 9)
        {
            day_text.text = "��ȩ° ��";
        }
        else if (GameManager.Instance.Days == 10)
        {
            day_text.text = "��° ��";
        }
    }

    public void ShowHow()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("How").gameObject;
        obj.SetActive(true);
    }

    public void CheckEnding()
    {
        if(GameManager.Instance.Days >= 11)
        {
            if(GameManager.Instance.getClues < 5)
            {
                Debug.Log("��忣��");
            }
        } else if(GameManager.Instance.townDead >= 20)
        {
            Debug.Log("��忣��");
        } else if(GameManager.Instance.getClues == 5)
        {
            if(GameManager.Instance.townAtmosphere > 50)
            {
                Debug.Log("�븻 ����");
            } else
            {
                Debug.Log("�� ����");
            }
        } else //�̺�Ʈ �߻� ����
        {
            //if (!GameManager.instance.TodayVisited)
            //{
                if (GameManager.Instance.eventAcrobat || GameManager.Instance.eventAlchem)
                {
                    if (GameManager.Instance.eventAcrobat)
                    {
                        AcrobatEv();
                    }
                    if (GameManager.Instance.eventAlchem)
                    {
                        AlchemEv();
                    }
                }
                else if (GameManager.Instance.Days >= 2 && GameManager.Instance.Days < 6)
                {
                    int eventHappen = Random.Range(0, 2);
                    if (eventHappen == 0)
                    {
                        Debug.Log("�̺�Ʈ ����");
                    }
                    else
                    {
                        int random = Random.Range(0, 4);

                        switch (random)
                        {
                            case 0:
                                HarvestEv();
                                break;
                            case 1:
                                if (GameManager.Instance.townAtmosphere > 50)
                                {
                                    SacrificeEv();
                                }
                                break;
                            case 2:
                                RiverEv();
                                break;
                            case 3:
                                FireEv();
                                break;
                        }
                    }
                }
                else if (GameManager.Instance.Days >= 6)
                {
                    int eventHappen = Random.Range(0, 2);
                    if (eventHappen == 0)
                    {
                        Debug.Log("�̺�Ʈ ����");
                    }
                    else
                    {
                        int random = Random.Range(0, 5);

                        switch (random)
                        {
                            case 0:
                                HarvestEv();
                                break;
                            case 1:
                                if (GameManager.Instance.townAtmosphere > 50)
                                {
                                    SacrificeEv();
                                }
                                break;
                            case 2:
                                RiverEv();
                                break;
                            case 3:
                                FireEv();
                                break;
                            case 4:
                                AppearEv();
                                break;
                        }
                    }
                }
            //}
        }
    }

    public void HarvestEv()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("Events").gameObject;
        GameObject Harvest = obj.transform.Find("EventHarvest").gameObject;
        Harvest.SetActive(true);
        int change = Random.Range(2, 5) * 500;
        HarEvent.text = change.ToString() + " ��尡 �����մϴ�.";
        GameManager.Instance.playerGold += change;
    }

    public void SacrificeEv()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("Events").gameObject;
        GameObject Sacrifice = obj.transform.Find("EventSacrifice").gameObject;
        Sacrifice.SetActive(true);
        int people = Random.Range(2, 5);
        SacEvent.text = "����� ���� " + people.ToString() + " �����մϴ�";
        GameManager.Instance.townDead += people;
    }

    public void AppearEv()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("Events").gameObject;
        GameObject Appear = obj.transform.Find("EventAppearance").gameObject;
        Appear.SetActive(true);
        int people = Random.Range(5, 8);
        AppEvent.text = "����� ���� " + people.ToString() + " �����մϴ�";
        GameManager.Instance.townDead += people;
    }

    public void RiverEv()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("Events").gameObject;
        GameObject River = obj.transform.Find("EventRiver").gameObject;
        River.SetActive(true);
        int atmos = Random.Range(10, 26);
        GameManager.Instance.townAtmosphere += atmos;
    }

    public void FireEv()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("Events").gameObject;
        GameObject Fire = obj.transform.Find("EventFire").gameObject;
        Fire.SetActive(true);
        int change = Random.Range(4, 11) * 500;
        FirEvent.text = change.ToString() + " ��尡 �����մϴ�.";
        GameManager.Instance.playerGold -= change;

        if (GameManager.Instance.playerGold < 0)
        {
            GameManager.Instance.playerGold = 0;
        }
    }

    public void AlchemEv()
    {
        GameManager.Instance.eventAlchem = false;
        GameObject obj = GameObject.Find("Canvas").transform.Find("Events").gameObject;
        GameObject alchem = obj.transform.Find("EventAlchemist").gameObject;
        alchem.SetActive(true);
        int change = Random.Range(5, 11) * 500;
        AlchemEvent.text = change.ToString() + " ��尡 �����մϴ�.";
        GameManager.Instance.playerGold += change;
    }

    public void AcrobatEv()
    {
        GameManager.Instance.eventAcrobat = false;
        GameObject obj = GameObject.Find("Canvas").transform.Find("Events").gameObject;
        GameObject acro = obj.transform.Find("EventAcrobat").gameObject;
        acro.SetActive(true);
        int atmos = Random.Range(10, 21);
        GameManager.Instance.townAtmosphere -= atmos;

        if(GameManager.Instance.townAtmosphere < 0)
        {
            GameManager.Instance.townAtmosphere = 0;
        }
    }
}
