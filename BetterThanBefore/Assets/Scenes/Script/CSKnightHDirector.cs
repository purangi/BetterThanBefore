using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSKnightHDirector : MonoBehaviour
{
    private GameObject keyObject;
    KnightHButton KnightSC;

    // Start is called before the first frame update
    void Start()
    {
        keyObject = GameObject.Find("KHKey"); //촛불 오브젝트
        keyObject.SetActive(false);
        KnightSC = GameObject.Find("KHCandle").GetComponent<KnightHButton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        if (KnightSC.IsCursorCandle == true)
        {
            keyObject.SetActive(true);
        }
    }
    
    void OnMouseExit()
    {
        if (KnightSC.IsCursorCandle == true)
        {
            keyObject.SetActive(false);
        }
    }
}
