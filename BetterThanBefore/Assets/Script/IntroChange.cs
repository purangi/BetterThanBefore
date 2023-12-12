using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class IntroChange : MonoBehaviour
{
    string path;

    public void Start()
    {
        path = Path.Combine(Application.dataPath, "database.json");

        if (!File.Exists(path))
        {
            GameObject skip = GameObject.Find("Canvas/Button");
            if(skip != null)
                skip.SetActive(false);
        }
    }
    public void SceneChange()
    {
        if(SceneManager.GetActiveScene().name == "IntroScene1")
        {
            SceneManager.LoadScene("IntroScene2");
        } else if(SceneManager.GetActiveScene().name == "IntroScene2")
        {
            SceneManager.LoadScene("IntroScene3");
        } else if(SceneManager.GetActiveScene().name == "IntroScene3")
        {
            SceneManager.LoadScene("IntroScene4");
        } else if(SceneManager.GetActiveScene().name == "IntroScene4")
        {
            SceneManager.LoadScene("IntroScene5");
        } else if(SceneManager.GetActiveScene().name == "IntroScene5")
        {
            SceneManager.LoadScene("IntroScene6");
        } else if(SceneManager.GetActiveScene().name == "IntroScene6")
        {
            SceneManager.LoadScene("IntroScene7");
        } else if(SceneManager.GetActiveScene().name == "IntroScene7")
        {
            SceneManager.LoadScene("StartScene");
        } 
    }

    public void SkipScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
