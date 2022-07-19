using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSPhotoEventManager : MonoBehaviour
{
    bool PhotoChk = false;

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
