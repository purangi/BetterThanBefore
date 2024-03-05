using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightHButton : MonoBehaviour
{
    public Texture2D cursorTextureA;
    public Texture2D cursorTextureB;
    //public bool IsCursorCandle;
    //public bool haveKey;
    private Vector2 hotSpot;

    private GameObject candleObject;
    private GameObject keyObject;

    bool objChk = false;
    bool IsExploreAble;
    
    public Sprite sprExpand; //Ŀ�� sprite
    public Sprite sprOrigin; //���� sprite

    private Inventory theInventory;  // Inventory.cs

    KnightHDirector kd;

    public bool RoomExplore
    {
        get { return IsExploreAble; }
        set { IsExploreAble = value; }
    }

    public void GetDismissal() //���Ӽ� ȹ��
    {
        GameObject obj = GameObject.Find("GameManager");
        if (obj == null)
        {
            Debug.Log("���Ӽ� ȹ�� �߸��� ���");
            GameManager.Instance.talents[0].haveWeakness = false;
        }
        else
        {
            GameManager.Instance.talents[0].haveWeakness = true;
        }
        /*
        GameObject obj = GameObject.Find("Canvas").transform.Find("Inventory").gameObject;
        theInventory = obj.GetComponent<Inventory>();

        GameObject dismissalObj = GameObject.Find("Canvas").transform.Find("KHDismissal").gameObject; //���Ӽ� ������Ʈ

        if (dismissalObj != null)
        {
            if(theInventory != null)
            {
                theInventory.AcquireItem(dismissalObj.transform.GetComponent<ItemPickUp>().item);
                Destroy(dismissalObj);
            }
        } */
    }

    public void GetCandle() //Ŀ�� ����
    {
        kd = GameObject.Find("KHKeyDrawer").GetComponent<KnightHDirector>();
        if (IsExploreAble == true)
        {
            candleObject = GameObject.Find("KHCandle"); //�к� ������Ʈ
            candleObject.SetActive(false);

            hotSpot.x = cursorTextureA.width / 2;
            hotSpot.y = cursorTextureA.height / 2;

            Cursor.SetCursor(cursorTextureA, hotSpot, CursorMode.ForceSoftware);
            kd.IsCursorCandle = true;
        }
    }

    public void GetKey() //���� ���
    {
        kd = GameObject.Find("KHKeyDrawer").GetComponent<KnightHDirector>();
        if (IsExploreAble && !kd.haveKey)
        {
            keyObject = GameObject.Find("KHKey"); //���� ������Ʈ

            hotSpot.x = cursorTextureB.width / 2;
            hotSpot.y = cursorTextureB.height / 2;

            Cursor.SetCursor(cursorTextureB, hotSpot, CursorMode.ForceSoftware);
            kd.haveKey = true;
            Destroy(keyObject);
        }
    }

    public void OpenDrawer()
    {
        kd = GameObject.Find("KHKeyDrawer").GetComponent<KnightHDirector>();
        if (kd.haveKey == true)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

            GameObject obj = GameObject.Find("Canvas").transform.Find("KHDismissal").gameObject;
            obj.SetActive(true);
            RectTransform rectTran = obj.GetComponent<RectTransform>();
            Vector3 position = obj.transform.localPosition;

            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 567);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 607);
            position.x = 0;
            position.y = 0;
            obj.transform.localPosition = position;

            kd.haveKey = false;
        }
    }

    public void LetterClickExpand() //���� Ȯ��
    {
        GameObject obj = GameObject.Find("KHLetter");
        RectTransform rectTran = obj.GetComponent<RectTransform>();
        Vector3 position = obj.transform.localPosition;

        if (IsExploreAble == true)
        {
            if (objChk == false)
            {
                obj.GetComponent<Image>().sprite = sprExpand;
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 417);
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 615);
                position.x = 0;
                position.y = 0;
                obj.transform.localPosition = position;
                objChk = true;
            } else 
            {
                obj.GetComponent<Image>().sprite = sprOrigin;
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 73);
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 25);
                position.x = -48;
                position.y = -101;
                obj.transform.localPosition = position;
                objChk = false;
            }
        }
    }

    public void PhotoClickExpand() //���� Ȯ��
    {
        GameObject obj = GameObject.Find("KHPhoto");
        RectTransform rectTran = obj.GetComponent<RectTransform>();
        Vector3 position = obj.transform.localPosition;

        if(IsExploreAble == true)
        {
            if (objChk == false)
            {
                obj.GetComponent<Image>().sprite = sprExpand;
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 389);
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 566);
                position.x = 0;
                position.y = 0;
                obj.transform.localPosition = position;
                objChk = true;
            } else
            {
                obj.GetComponent<Image>().sprite = sprOrigin;
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 135);
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 93);
                position.x = -299;
                position.y = 34;
                obj.transform.localPosition = position;
                objChk = false;
            }
        }

    }
}
