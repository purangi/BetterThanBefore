using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercenaryHDirector : MonoBehaviour
{
    public bool IsCursorEmpty;
    public bool IsCursorFull;
    public bool IsAwake;

    private GameObject wantedObj;

    // Start is called before the first frame update
    void Start()
    {
        wantedObj = GameObject.Find("MHWanted"); //���Ӽ� ������Ʈ
        wantedObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
