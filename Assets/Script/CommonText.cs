using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommonText : MonoBehaviour
{
    private TextMeshProUGUI CommonNumber; 
    private int ChangeCommon = 0; 

    // Start is called before the first frame update
    void Start()
    {
        CommonNumber = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        CommonNumber.text = "x" + ChangeCommon.ToString();
    }
    /* void HireCommon()
    {
        if() // 평민을 고용했을때
        {
            ChangeCommon += 1;
        }
    } */
}
