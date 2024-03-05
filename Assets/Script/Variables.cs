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
            //Debug.Log("���� " + gold);
        } else
        {
            gold = GameManager.Instance.playerGold;
            //Debug.Log("���� " + gold);
        }
    }

    public static void SetAtmos()
    {
        GameObject obj = GameObject.Find("GameManager");
        if (obj == null)
        {
            atmos = 0;
            //Debug.Log("������ " + atmos);
        }
        else
        {
            atmos = GameManager.Instance.townAtmosphere;
            //Debug.Log("������ " + atmos);
        }
    }

    public bool GetAtmos()
    {
        SetAtmos();

        if (atmos > 50) //������ ����
        {
            return false;
        }
        else //������ ����
        {
            return true;
        }
    }

    /*
    [YarnFunction("knight_visited")]
    public static int KnightVisited()
    {
        if (GameManager.instance.KnightVisited == 0) //ù�湮
        {
            return 0;
        }
        else if (GameManager.instance.KnightVisited == 1) //���� �湮
        {
            return 1;
        }
        else if (GameManager.instance.KnightVisited == 2) //��� ���� �湮
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
            return true; //��� ���
        } else
        {
            return false; //��� ����
        }
    }

    [YarnFunction("check_atmos")]
    public static bool checkAtmos() //���� ������
    {
        SetAtmos();

        if (atmos >= 51) //������ ����
        {
            return false;
        }
        else //������ ����
        {
            return true;
        }
    }

    //TODO:YarnFunction ����

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
            if (GameManager.instance.haveDismissal) //���Ӽ� ���� ��
            {
                Debug.Log("���Ӽ� ����");
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
            if (GameManager.instance.haveWanted) //���Ӽ� ���� ��
            {
                Debug.Log("������ ����");
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
            if (GameManager.instance.haveDrug) //���Ӽ� ���� ��
            {
                Debug.Log("����� ����");
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
            if (GameManager.instance.haveRock) //���Ӽ� ���� ��
            {
                Debug.Log("¯�� ����");
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
