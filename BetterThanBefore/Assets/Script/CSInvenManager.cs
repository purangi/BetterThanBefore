using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSInvenManager : MonoBehaviour
{
    private GameObject InvenObject;
    // Start is called before the first frame update
    void Start()
    {
        InvenObject = GameObject.Find("Inventory");
        InvenObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
