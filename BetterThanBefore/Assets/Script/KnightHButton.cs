using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHButton : MonoBehaviour
{
    public Texture2D cursorTextureA;
    public Texture2D cursorTextureB;
    public bool IsCursorCandle;

    private Vector2 hotSpot;

    private GameObject candleObject;
    private GameObject keyObject;

    bool LetterChk = false;
    bool PhotoChk = false;

    public void GetCandle() //Ŀ�� ����
    {
        candleObject = GameObject.Find("KHCandle"); //�к� ������Ʈ
        candleObject.SetActive(false);

        hotSpot.x = cursorTextureA.width / 2;
        hotSpot.y = cursorTextureA.height / 2;
       
        Cursor.SetCursor(cursorTextureA, hotSpot, CursorMode.ForceSoftware);
        IsCursorCandle = true;
    }

    public void GetKey() //���� ���
    {
        keyObject = GameObject.Find("KHKey"); //���� ������Ʈ

        hotSpot.x = cursorTextureB.width / 2;
        hotSpot.y = cursorTextureB.height / 2;

        Cursor.SetCursor(cursorTextureB, hotSpot, CursorMode.ForceSoftware);
        keyObject.SetActive(false);
    }

    public void OpenDrawer()
    {
        if (GameObject.Find("Canvas").transform.Find("KHKey").gameObject.activeSelf == false) //�κ��丮�� �����ؾ��ҵ�
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            Debug.Log("ȹ��");
        } else
        {
            Debug.Log("����");
        }
    }

    public void LetterClickExpand() //���� Ȯ��
    {
        RectTransform rectTran = gameObject.GetComponent<RectTransform>();
        GameObject obj = GameObject.Find("KHLetter");
        Vector3 position = obj.transform.localPosition;

        if (LetterChk == false)
        {
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 450);
            position.x = 0;
            position.y = 0;
            obj.transform.localPosition = position;
            obj.transform.localPosition = position;
            LetterChk = true;
        }

        else
        {
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 130);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);
            position.x = -172;
            position.y = -52;
            obj.transform.localPosition = position;
            LetterChk = false;
        }
    }

    public void PhotoClickExpand() //���� Ȯ��
    {
        RectTransform rectTran = gameObject.GetComponent<RectTransform>();
        GameObject obj = GameObject.Find("KHPhoto");
        Vector3 position = obj.transform.localPosition;

        if (PhotoChk == false)
        {
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 800);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 760);
            obj.transform.SetAsLastSibling();
            position.x = 0;
            position.y = 0;
            obj.transform.localPosition = position;
            PhotoChk = true;
        }

        else
        {
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 190);
            position.x = -336;
            position.y = 214;
            obj.transform.localPosition = position;
            PhotoChk = false;
        }
    }
}
