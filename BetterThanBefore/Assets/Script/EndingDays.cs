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
        if (GameManager.instance.Days == 1)
        {
            day_text.text = "첫째 날";
            if(!GameManager.instance.TodayVisited)
            {
                ShowHow();
            }
        } else if(GameManager.instance.Days == 2)
        {
            day_text.text = "둘째 날";
        }
        else if (GameManager.instance.Days == 3)
        {
            day_text.text = "셋째 날";
        }
        else if (GameManager.instance.Days == 4)
        {
            day_text.text = "넷째 날";
        }
        else if (GameManager.instance.Days == 5)
        {
            day_text.text = "다섯째 날";
        }
        else if (GameManager.instance.Days == 6)
        {
            day_text.text = "여섯째 날";
        }
        else if (GameManager.instance.Days == 7)
        {
            day_text.text = "일곱째 날";
        }
        else if (GameManager.instance.Days == 8)
        {
            day_text.text = "여덟째 날";
        }
        else if (GameManager.instance.Days == 9)
        {
            day_text.text = "아홉째 날";
        }
        else if (GameManager.instance.Days == 10)
        {
            day_text.text = "열째 날";
        }
    }

    
    public void ShowHow()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("How").gameObject;
        obj.SetActive(true);
    }

    public void CheckEnding()
    {
        if(GameManager.instance.Days >= 11)
        {
            if(GameManager.instance.getClues < 5)
            {
                Debug.Log("배드엔딩");
            }
        } else if(GameManager.instance.townDead >= 20)
        {
            Debug.Log("배드엔딩");
        } else if(GameManager.instance.getClues == 5)
        {
            if(GameManager.instance.townAtmosphere > 50)
            {
                Debug.Log("노말 엔딩");
            } else
            {
                Debug.Log("진 엔딩");
            }
        } else //이벤트 발생 가능
        {
            if (!GameManager.instance.TodayVisited)
            {
                if (GameManager.instance.eventAcrobat || GameManager.instance.eventAlchem)
                {
                    if (GameManager.instance.eventAcrobat)
                    {
                        AcrobatEv();
                    }
                    if (GameManager.instance.eventAlchem)
                    {
                        AlchemEv();
                    }
                }
                else if (GameManager.instance.Days >= 2 && GameManager.instance.Days < 6)
                {
                    int eventHappen = Random.Range(0, 2);
                    if (eventHappen == 0)
                    {
                        Debug.Log("이벤트 없음");
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
                                if (GameManager.instance.townAtmosphere > 50)
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
                else if (GameManager.instance.Days >= 6)
                {
                    int eventHappen = Random.Range(0, 2);
                    if (eventHappen == 0)
                    {
                        Debug.Log("이벤트 없음");
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
                                if (GameManager.instance.townAtmosphere > 50)
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
            }
        }
    }

    public void HarvestEv()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("Events").gameObject;
        GameObject Harvest = obj.transform.Find("EventHarvest").gameObject;
        Harvest.SetActive(true);
        int change = Random.Range(2, 5) * 500;
        HarEvent.text = change.ToString() + " 골드가 증가합니다.";
        GameManager.instance.playerGold += change;
    }

    public void SacrificeEv()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("Events").gameObject;
        GameObject Sacrifice = obj.transform.Find("EventSacrifice").gameObject;
        Sacrifice.SetActive(true);
        int people = Random.Range(2, 5);
        SacEvent.text = "사망자 수가 " + people.ToString() + " 증가합니다";
        GameManager.instance.townDead += people;
    }

    public void AppearEv()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("Events").gameObject;
        GameObject Appear = obj.transform.Find("EventAppearance").gameObject;
        Appear.SetActive(true);
        int people = Random.Range(5, 8);
        AppEvent.text = "사망자 수가 " + people.ToString() + " 증가합니다";
        GameManager.instance.townDead += people;
    }

    public void RiverEv()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("Events").gameObject;
        GameObject River = obj.transform.Find("EventRiver").gameObject;
        River.SetActive(true);
        int atmos = Random.Range(10, 26);
        GameManager.instance.townAtmosphere += atmos;
    }

    public void FireEv()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("Events").gameObject;
        GameObject Fire = obj.transform.Find("EventFire").gameObject;
        Fire.SetActive(true);
        int change = Random.Range(4, 11) * 500;
        FirEvent.text = change.ToString() + " 골드가 감소합니다.";
        GameManager.instance.playerGold -= change;

        if (GameManager.instance.playerGold < 0)
        {
            GameManager.instance.playerGold = 0;
        }
    }

    public void AlchemEv()
    {
        GameManager.instance.eventAlchem = false;
        GameObject obj = GameObject.Find("Canvas").transform.Find("Events").gameObject;
        GameObject alchem = obj.transform.Find("EventAlchemist").gameObject;
        alchem.SetActive(true);
        int change = Random.Range(5, 11) * 500;
        AlchemEvent.text = change.ToString() + " 골드가 증가합니다.";
        GameManager.instance.playerGold += change;
    }

    public void AcrobatEv()
    {
        GameManager.instance.eventAcrobat = false;
        GameObject obj = GameObject.Find("Canvas").transform.Find("Events").gameObject;
        GameObject acro = obj.transform.Find("EventAcrobat").gameObject;
        acro.SetActive(true);
        int atmos = Random.Range(10, 21);
        GameManager.instance.townAtmosphere -= atmos;

        if(GameManager.instance.townAtmosphere < 0)
        {
            GameManager.instance.townAtmosphere = 0;
        }
    }
}
