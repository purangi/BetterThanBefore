using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSStart : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("MainScene");
        Debug.Log("게임 시작");
    }

    public void GameExit()
    {
        Application.Quit();
        Debug.Log("게임 종료");
    }
}
