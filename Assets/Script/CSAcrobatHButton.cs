using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSAcrobatHButton : MonoBehaviour
{
    bool BHChk = false;

    public Sprite ExpBH;
    public Sprite OrBH;

    private GameObject BreadObject;
    private Vector2 hotSpot;
    public Texture2D cursorBread;

    public bool IsCursorBread = false;

    private Image HungryImage;
    public Sprite FullImage;
    public Texture2D cursorNeedle;

    public bool IsCursorNeedle = false;

    private GameObject BallObject;

    void Start()
    {
        HungryImage = GetComponent<Image>();
    }

    public void NewsClickExpand()
    {
        GameObject News = GameObject.Find("BHNews");
        RectTransform rectTran = News.GetComponent<RectTransform>();
        Vector3 position = News.transform.localPosition;

        if (BHChk == false)
        {
            News.GetComponent<Image>().sprite = ExpBH;
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 694);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 496);
            position.x = 0;
            position.y = 0;
            News.transform.localPosition = position;
            BHChk = true;
        }
        else
        {
            News.GetComponent<Image>().sprite = OrBH;
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 75);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 91);
            position.x = -131;
            position.y = -86;
            News.transform.localPosition = position;
            BHChk = false;
        }
    }

    public void BHLetterClickExpand()
    {
        GameObject Letter = GameObject.Find("BHLetter");
        RectTransform rectTran = Letter.GetComponent<RectTransform>();
        Vector3 position = Letter.transform.localPosition;

        if (BHChk == false)
        {
            Letter.transform.SetSiblingIndex(6);
            Letter.GetComponent<Image>().sprite = ExpBH;
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 452);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 568);
            position.x = 0;
            position.y = 0;
            Letter.transform.localPosition = position;
            BHChk = true;
        }
        else
        {
            Letter.transform.SetSiblingIndex(5);
            Letter.GetComponent<Image>().sprite = OrBH;
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 35);
            position.x = 147;
            position.y = -252;
            Letter.transform.localPosition = position;
            BHChk = false;
        }
    }
    public void GetBread()
    {
        BreadObject = GameObject.Find("BHBread");
        BreadObject.SetActive(false);

        hotSpot.x = cursorBread.width / 2;
        hotSpot.y = cursorBread.height / 2;

        Cursor.SetCursor(cursorBread, hotSpot, CursorMode.ForceSoftware);

        IsCursorBread = true;
    }

    public void GetNeedle()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("BHBread").gameObject;
        CSAcrobatHButton ab = obj.GetComponent<CSAcrobatHButton>();

        if (ab.IsCursorBread == true)
        {
            HungryImage.sprite = FullImage;

            hotSpot.x = cursorNeedle.width / 2;
            hotSpot.y = cursorNeedle.height / 2;

            Cursor.SetCursor(cursorNeedle, hotSpot, CursorMode.ForceSoftware);

            IsCursorNeedle = true;
        }
    }

    public void RealBall()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("BHMouse").gameObject;
        CSAcrobatHButton ab = obj.GetComponent<CSAcrobatHButton>();

        if (ab.IsCursorNeedle == true)
        {
            BallObject = GameObject.Find("BHBall");
            BallObject.SetActive(false);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            GameObject drug = GameObject.Find("Canvas").transform.Find("BHDrug").gameObject;
            drug.SetActive(true);
        }
    }

    public void GetDrug()
    {
        //TODO: 어따 쓴거임?
        /*
        GameObject obj = GameObject.Find("GameManager");
        if (obj == null)
        {
            GameManager.instance.haveDrug = false;
        }
        else
        {
            GameManager.instance.haveDrug = true;
        } */
    }

}