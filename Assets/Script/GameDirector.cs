using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    private GameObject gm;
    private GameObject bgm;
    private GameObject inven;

    void Awake()
    {
        gm = GameObject.Find("GameManager");
        bgm = GameObject.Find("BackGroundMusic");
        DontDestroyOnLoad(gm);
        DontDestroyOnLoad(bgm);
    }
}
