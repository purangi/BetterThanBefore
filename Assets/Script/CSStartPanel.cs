using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSStartPanel : MonoBehaviour
{
    public GameObject StartPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartPanel.SetActive(false);
        Invoke("LoadPanel", 4.0f);
    }
    
    void LoadPanel()
    {
        StartPanel.SetActive(true);
    }
}
