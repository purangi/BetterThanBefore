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

    public void GetCandle() //커서 변경
    {
        candleObject = GameObject.Find("KHCandle"); //촛불 오브젝트
        candleObject.SetActive(false);

        hotSpot.x = cursorTextureA.width / 2;
        hotSpot.y = cursorTextureA.height / 2;
       
        Cursor.SetCursor(cursorTextureA, hotSpot, CursorMode.ForceSoftware);
        IsCursorCandle = true;
    }

    public void GetKey() //열쇠 얻기
    {
        keyObject = GameObject.Find("KHKey"); //열쇠 오브젝트

        hotSpot.x = cursorTextureB.width / 2;
        hotSpot.y = cursorTextureB.height / 2;

        Cursor.SetCursor(cursorTextureB, hotSpot, CursorMode.ForceSoftware);
        keyObject.SetActive(false);
    }

    public void OpenDrawer()
    {
        if (GameObject.Find("Canvas").transform.Find("KHKey").gameObject.activeSelf == false) //인벤토리로 연결해야할듯
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            Debug.Log("획득");
        } else
        {
            Debug.Log("실패");
        }
    }

    public void LetterClickExpand() //편지 확대
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

    public void PhotoClickExpand() //사진 확대
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
