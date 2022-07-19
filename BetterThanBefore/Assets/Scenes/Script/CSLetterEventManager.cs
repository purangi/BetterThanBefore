using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSLetterEventManager : MonoBehaviour
{
    bool LetterChk = false;

    public void LetterClickExpand() //편지 확대
    {
        RectTransform rectTran = gameObject.GetComponent<RectTransform>();
        GameObject obj = GameObject.Find("KHLetter");
        Vector3 position = obj.transform.localPosition;

        if (LetterChk == false)
        {
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 455);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 805);
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

}
