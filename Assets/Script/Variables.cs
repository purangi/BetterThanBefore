using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Variables : MonoBehaviour
{
    private static int gold;
    private static int atmos;

    public static void SetGold()
    {
        GameObject obj = GameObject.Find("GameManager");
        if(obj == null)
        {
            gold = 1000;
            //Debug.Log("골드는 " + gold);
        } else
        {
            gold = GameManager.Instance.playerGold;
            //Debug.Log("골드는 " + gold);
        }
    }

    public static void SetAtmos()
    {
        GameObject obj = GameObject.Find("GameManager");
        if (obj == null)
        {
            atmos = 0;
            //Debug.Log("분위기 " + atmos);
        }
        else
        {
            atmos = GameManager.Instance.townAtmosphere;
            //Debug.Log("분위기 " + atmos);
        }
    }

    public bool GetAtmos()
    {
        SetAtmos();

        if (atmos > 50) //분위기 나쁨
        {
            return false;
        }
        else //분위기 좋음
        {
            return true;
        }
    }

    /*
    [YarnFunction("knight_visited")]
    public static int KnightVisited()
    {
        if (GameManager.instance.KnightVisited == 0) //첫방문
        {
            return 0;
        }
        else if (GameManager.instance.KnightVisited == 1) //재고용 방문
        {
            return 1;
        }
        else if (GameManager.instance.KnightVisited == 2) //골드 부족 방문
        {
            return 2;
        } else
        {
            return 5;
        }
    }

    [YarnFunction("mercenary_visited")]
    public static int MercenaryVisited()
    {
        if (GameManager.instance.MercenaryVisited == 0)
        {
            return 0;
        }
        else if (GameManager.instance.MercenaryVisited == 1)
        {
            return 1;
        }
        else if (GameManager.instance.MercenaryVisited == 2)
        {
            return 2;
        } else
        {
            return 5;
        }
    }

    [YarnFunction("alchem_visited")]
    public static int AlchemVisited()
    {
        if (GameManager.instance.AlchemVisited == 0)
        {
            return 0;
        }
        else if (GameManager.instance.AlchemVisited == 1)
        {
            return 1;
        }
        else if (GameManager.instance.AlchemVisited == 2)
        {
            return 2;
        }
        else
        {
            return 5;
        }
    }

    [YarnFunction("acrobat_visited")]
    public static int AcrobatVisited()
    {
        if (GameManager.instance.AcrobatVisited == 0)
        {
            return 0;
        }
        else if(GameManager.instance.AcrobatVisited == 1)
        {
            return 1;
        } else if (GameManager.instance.AcrobatVisited == 2)
        {
            return 2;
        }
        else
        {
            return 5;
        }
    } */

    [YarnFunction("check_gold")]
    public static bool checkGold(string talent) 
    {
        SetGold();

        int checkGold = 0;

        if(talent == "Knight")
        {
            checkGold = 1500;
        } else if(talent == "Mercenary")
        {
            checkGold = 2500;
        } else if(talent == "Alchem")
        {
            checkGold = 2500;
        } else if(talent == "Acrobat")
        {
            checkGold = 2000;
        }

        Debug.Log(checkGold);
        if(gold >= checkGold)
        {
            return true; //골드 충분
        } else
        {
            return false; //골드 부족
        }
    }

    [YarnFunction("check_atmos")]
    public static bool checkAtmos() //영지 분위기
    {
        SetAtmos();

        if (atmos >= 51) //분위기 나쁨
        {
            return false;
        }
        else //분위기 좋음
        {
            return true;
        }
    }

    //TODO:YarnFunction 정리

    /*
    [YarnFunction("check_dismiss")]
    public static bool checkDismiss()
    {
        GameObject obj = GameObject.Find("GameManager");
        if (obj == null)
        {
            return false;
        }
        else
        {
            if (GameManager.instance.haveDismissal) //해임서 있을 때
            {
                Debug.Log("해임서 있음");
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    [YarnFunction("check_wanted")]
    public static bool CheckWanted()
    {
        GameObject obj = GameObject.Find("GameManager");
        if (obj == null)
        {
            return false;
        }
        else
        {
            if (GameManager.instance.haveWanted) //해임서 있을 때
            {
                Debug.Log("수배지 있음");
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    [YarnFunction("check_drug")]
    public static bool CheckDrug()
    {
        GameObject obj = GameObject.Find("GameManager");
        if (obj == null)
        {
            return false;
        }
        else
        {
            if (GameManager.instance.haveDrug) //해임서 있을 때
            {
                Debug.Log("마약공 있음");
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    [YarnFunction("check_rock")]
    public static bool CheckRock()
    {
        GameObject obj = GameObject.Find("GameManager");
        if (obj == null)
        {
            return false;
        }
        else
        {
            if (GameManager.instance.haveRock) //해임서 있을 때
            {
                Debug.Log("짱돌 있음");
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    */
}
