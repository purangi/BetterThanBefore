using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSExCommon : MonoBehaviour
{
    public Text ExCommon;
    public int ChangeCom = 30; //최대로 잡음

    public Sprite CoOther;
    public Image CoSwitch;

    // Start is called before the first frame update
    void Start()
    {
        ExCommon = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExChangeCommon()
    {
        if (ChangeCom > 1)
        {
            ChangeCom -= 1;
            ExCommon.text = "x " + ChangeCom.ToString();
        }

        if (ChangeCom == 1)
        {
            ChangeCom = 0;
            ExCommon.text = "x " + ChangeCom.ToString();
            CoSwitch.sprite = CoOther;
        }
    }
}
