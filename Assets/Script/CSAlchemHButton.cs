using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSAlchemHButton : MonoBehaviour
{
    bool DrisChk = false;

    public Sprite ExpDris;
    public Sprite OrDris;

    private GameObject DrugObject;
    private Vector2 hotSpot;
    public Texture2D cursorDrug;

    public bool IsCursorDrug = false;

    private GameObject AssembleObject;
    public Texture2D cursorAssemble;

    public bool IsCursorAssemble = false;

    private List<Talent> talents = GameManager.instance.talents;
    void Start()
    {
    }

    public void DrisClickExpand()
    {
        GameObject Dris = GameObject.Find("AHDrugInstruction");
        RectTransform rectTran = Dris.GetComponent<RectTransform>();
        Vector3 position = Dris.transform.localPosition;

        if (DrisChk == false)
        {
            Dris.GetComponent<Image>().sprite = ExpDris;
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 530);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 658);
            position.x = 0;
            position.y = 0;
            Dris.transform.localPosition = position;
            DrisChk = true;
        }
        else
        {
            Dris.GetComponent<Image>().sprite = OrDris;
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 79);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 25);
            position.x = 180;
            position.y = -129;
            Dris.transform.localPosition = position;
            DrisChk = false;
        }
    }

    public void GetDrug()
    {

            DrugObject = GameObject.Find("AHEmptyDrug");
            DrugObject.SetActive(false);

            hotSpot.x = cursorDrug.width / 2;
            hotSpot.y = cursorDrug.height / 2;

            Cursor.SetCursor(cursorDrug, hotSpot, CursorMode.ForceSoftware);
    }

    public void GetAssemble()
    {
        IsCursorAssemble = true;

        AssembleObject = GameObject.Find("AHAssembleChemical");
        AssembleObject.SetActive(false);

        hotSpot.x = cursorAssemble.width / 2;
        hotSpot.y = cursorAssemble.height / 2;

        Cursor.SetCursor(cursorAssemble, hotSpot, CursorMode.ForceSoftware);
    }

    public void HelpLimit()
    {
        IsCursorDrug = true;
    }

    public void UnRock()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("AHChemicalFlask").gameObject;
        CSAlchemHButton ab = obj.GetComponent<CSAlchemHButton>();

        if (ab.IsCursorDrug == true && !talents[3].haveWeakness)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

            GameObject rock = GameObject.Find("Canvas").transform.Find("AHRock").gameObject;
            rock.SetActive(true);

            //인벤토리 구현 후 코드 구현
        }
    }

    public void Change()
    {
        GameObject obj = GameObject.Find("Canvas").transform.Find("AHAssembleChemical").gameObject;
        CSAlchemHButton ab = obj.GetComponent<CSAlchemHButton>();

        if (ab.IsCursorAssemble == true)
        {
            Debug.Log("변화 시도");

            GameObject Puzzle = GameObject.Find("CanvasTwo");
            Vector3 position = Puzzle.transform.localPosition;
            position.x = 0;
            position.y = 0;
            Puzzle.transform.localPosition = position;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

    }

    public void GetRock()
    {
        GameObject obj = GameObject.Find("GameManager");
        if (obj == null)
        {
            talents[3].haveWeakness = false;
        }
        else
        {
            talents[3].haveWeakness = true;
        }

        GameManager.instance.talents = talents;
    }
}
