using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHDirector : MonoBehaviour
{
    private GameObject keyObject;
    private GameObject dismissalObj;

    public bool IsCursorCandle;
    public bool haveKey;

    // Start is called before the first frame update
    void Start()
    {
        keyObject = GameObject.Find("KHKey"); //키 오브젝트
        keyObject.SetActive(false);
        //KnightSC = GameObject.Find("KHCandle").GetComponent<KnightHButton>();
        dismissalObj = GameObject.Find("KHDismissal"); //해임서 오브젝트
        dismissalObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseEnter()
    {
        if (IsCursorCandle && !haveKey)
        {
            if(keyObject != null)
            {
                keyObject.SetActive(true);
            }
        }
    }
    
    void OnMouseExit()
    {
        if (IsCursorCandle == true && keyObject != null)
        {
            keyObject.SetActive(false);
        }
    }
}
