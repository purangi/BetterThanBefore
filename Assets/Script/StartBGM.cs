using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBGM : MonoBehaviour
{
    public AudioClip intro;
    public AudioClip main;
    public AudioClip GKnight;
    public AudioClip BKnight;
    public AudioClip GMercenary;
    public AudioClip Alchemist;
    public AudioClip Acrobat;
    /*
    public AudioClip HireSuccess;
    public AudioClip HirePass;
    public AudioClip Explore; */

    public AudioClip Bad;
    public AudioClip Normal;
    public AudioClip Real;

    void Update()
    {
        CheckScene();
    }

    void CheckScene()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if(SceneManager.GetActiveScene().name == "StartScene" || SceneManager.GetActiveScene().name == "MainScene")
        {
            audio.clip = main;
        }
        else if (SceneManager.GetActiveScene().name == "KnightHScene")
        {
            audio.clip = GKnight;
            /*
            if (GameManager.instance.townAtmosphere <= 50)
            {
                audio.clip = GKnight;
            }
            else
            {
                audio.clip = BKnight;
            } */
        }
        else if (SceneManager.GetActiveScene().name == "MercenaryHScene")
        {
            audio.clip = GMercenary;
        }
        else if (SceneManager.GetActiveScene().name == "AlchemHScene")
        {
            audio.clip = Alchemist;
        }
        else if (SceneManager.GetActiveScene().name == "AcrobatHScene")
        {
            audio.clip = Acrobat;
        }
        else if (SceneManager.GetActiveScene().name == "BadEnding")
        {
            audio.clip = Bad;
        }
        else if (SceneManager.GetActiveScene().name == "NormalEnding")
        {
            audio.clip = Normal;
        }
        else if (SceneManager.GetActiveScene().name == "HappyEnding")
        {
            audio.clip = Real;
        } else
        {
            audio.clip = intro;
        }


        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }
}
