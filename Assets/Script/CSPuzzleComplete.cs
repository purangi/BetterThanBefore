using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSPuzzleComplete : MonoBehaviour
{
    public Transform CheckOne;
    public Transform CheckTwo;
    public Transform CheckThree;

    public Sprite Full;

    public Sprite After;

    bool shouldEvaluate = true;

    private Vector2 hotSpot;
    public Texture2D cursorClear;

    void Update()
    {
        GameObject EmptyObject = GameObject.Find("PuzzleFulling");

        if (CheckOne.GetSiblingIndex() == 2 && CheckTwo.GetSiblingIndex() == 0
            && CheckThree.GetSiblingIndex() == 1 && shouldEvaluate)
        {
            EmptyObject.GetComponent<Image>().sprite = Full;
            shouldEvaluate = false;
            Invoke("RealComplete", 2f);
        }
    }

    void RealComplete()
    {
        GameObject FlaskObject = GameObject.Find("AHChemicalFlask");
        FlaskObject.GetComponent<Image>().sprite = After;
        hotSpot.x = cursorClear.width / 2;
        hotSpot.y = cursorClear.height / 2;
        Cursor.SetCursor(cursorClear, hotSpot, CursorMode.ForceSoftware);
        GameObject PuzzleObject = GameObject.Find("CanvasTwo");
        PuzzleObject.SetActive(false);

        GameObject obj = GameObject.Find("Canvas").transform.Find("AHChemicalFlask").gameObject;
        CSAlchemHButton ab = obj.GetComponent<CSAlchemHButton>();

        ab.HelpLimit();
    }

}