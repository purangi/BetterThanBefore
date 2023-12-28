using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class IntroChange : MonoBehaviour
{
    public VideoPlayer myVideo;
    public VideoClip[] clips;
    public GameObject nextBtn;
    string path;

    int sceneNum = 0;

    public float playTime = 0f;

    public void Start()
    {
        playTime = (float) myVideo.length;
        sceneNum = 0;
        path = Path.Combine(Application.dataPath, "database.json");

        if (!File.Exists(path))
        {
            GameObject skip = GameObject.Find("Canvas/Button");
            if(skip != null)
                skip.SetActive(false);
        }
    }

    void Update()
    {
        playTime -= Time.deltaTime;

        if (playTime < 0.1f)
        {
            playTime = 0.0f;
            nextBtn.SetActive(true);
        }
    }

    public void VideoChange()
    {
        sceneNum++;
        if (sceneNum < 7)
        {
            nextBtn.SetActive(false);
            myVideo.clip = clips[sceneNum];
            myVideo.time = 0f;
            playTime = (float) myVideo.length;
            myVideo.Play();
        } else
        {
            SkipScene();
        }
    }

    public void SkipScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
