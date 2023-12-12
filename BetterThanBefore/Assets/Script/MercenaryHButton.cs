using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MercenaryHButton : MonoBehaviour
{
    bool objCheck = false;

    public Sprite Expand; //커진 sprite
    public Sprite Origin; //원래 sprite

    private GameObject DropObject;
    public Texture2D cursorEmpty;
    private Vector2 hotSpot;

    public Texture2D cursorFull;
    //public bool IsCursorFull = false;

    MercenaryHDirector md;

    void Start()
    {

    }

    public void OpinionClickExpand() //소견서 확대
    {
        GameObject obj = GameObject.Find("MHWrittenOpinion");
        RectTransform rectTran = obj.GetComponent<RectTransform>();
        Vector3 position = obj.transform.localPosition;

        if (objCheck == false)
        {
            obj.GetComponent<Image>().sprite = Expand;
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 447);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 663);
            position.x = 0;
            position.y = 0;
            obj.transform.localPosition = position;
            objCheck = true;
        }
        else
        {
            obj.GetComponent<Image>().sprite = Origin;
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 68);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 31);
            position.x = 172;
            position.y = -43;
            obj.transform.localPosition = position;
            objCheck = false;
        }
    }

    public void GetEmpty() //빈병으로 커서 변경
    {
        DropObject = GameObject.Find("MHDropAlcohol");
        DropObject.SetActive(false);

        md = GameObject.Find("MHBackGround").GetComponent<MercenaryHDirector>();

        hotSpot.x = cursorEmpty.width / 2;
        hotSpot.y = cursorEmpty.height / 2;

        Cursor.SetCursor(cursorEmpty, hotSpot, CursorMode.ForceSoftware);
        md.IsCursorEmpty = true;
    }

    public void GetFull() //가득한병으로 커서 변경
    {
        md = GameObject.Find("MHBackGround").GetComponent<MercenaryHDirector>();
        if(md.IsCursorEmpty)
        {
            hotSpot.x = cursorFull.width / 2;
            hotSpot.y = cursorFull.height / 2;

            Cursor.SetCursor(cursorFull, hotSpot, CursorMode.ForceSoftware);
            md.IsCursorEmpty = false;
            md.IsCursorFull = true;
        }
    }

    public void AwakeDrunkard()
    {
        md = GameObject.Find("MHBackGround").GetComponent<MercenaryHDirector>();

        GameObject obj = GameObject.Find("MHGarbageDrunkard");
        RectTransform rectTran = obj.GetComponent<RectTransform>();
        Vector3 position = obj.transform.localPosition;

        if (md.IsCursorFull == true)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

            obj.GetComponent<Image>().sprite = Expand;
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 164);
            position.x = 332;
            position.y = -89;
            obj.transform.localPosition = position;

            GameObject GarbageObj = GameObject.Find("Canvas").transform.Find("MHCanGarbage").gameObject;
            GarbageObj.SetActive(true);

            md.IsCursorFull = false;
        }
        else
        {
            Debug.Log("아무 일도 일어나지 않음");
        }
    }

    public void GetWanted()
    {
        GameObject obj = GameObject.Find("GameManager");
        if (obj == null)
        {
            Debug.Log("현상수배지 획득 잘못된 경로");
            GameManager.instance.haveWanted = false;
        }
        else
        {
            GameManager.instance.haveWanted = true;
        }
    }
}
