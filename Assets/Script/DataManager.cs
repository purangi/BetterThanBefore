using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

[System.Serializable]
public class SaveData
{
    public int gold;
    public int atmosphere;
    public int dead;

    public bool[] haveWeakness = new bool[4];
    public bool[] employTalents = new bool[4];
    public int[] TalentVisited = new int[4];

    public int employCommoner;
    public int getClues;
    public int Days;
    public bool TodayVisited;
    public bool eventAcrobat;
    public bool eventAlchem;
}

public class DataManager : MonoBehaviour
{
    string path;

    // Start is called before the first frame update
    void Start()
    {
        path = Path.Combine(Application.dataPath, "database.json");
        //JsonLoad();
    }

    // Update is called once per frame
    public void JsonLoad()
    {
        SaveData saveData = new SaveData();

        if(!File.Exists(path))
        {
            GameManager.instance.playerGold = 6000;
            GameManager.instance.townAtmosphere = 0;
            GameManager.instance.townDead = 0;

            GameManager.instance.haveDismissal = false;
            GameManager.instance.haveWanted = false;
            GameManager.instance.haveRock = false;
            GameManager.instance.haveDrug = false;

            GameManager.instance.employKnight = false;
            GameManager.instance.employMercenary = false;
            GameManager.instance.employAcrobat = false;
            GameManager.instance.employAlchem = false;

            GameManager.instance.KnightVisited = 0;
            GameManager.instance.MercenaryVisited = 0;
            GameManager.instance.AlchemVisited = 0;
            GameManager.instance.AcrobatVisited = 0;

            GameManager.instance.employCommoner = 0;

            GameManager.instance.getClues = 0;

            GameManager.instance.Days = 1;
            GameManager.instance.TodayVisited = false;
            GameManager.instance.eventAcrobat = false;
            GameManager.instance.eventAlchem = false;

            Debug.Log("세이브 파일이 없습니다.");

            JsonSave();
        } else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if(saveData != null)
            {
                GameManager.instance.playerGold = saveData.gold;
                GameManager.instance.townAtmosphere = saveData.atmosphere;
                GameManager.instance.townDead = saveData.dead;

                GameManager.instance.haveDismissal = saveData.haveWeakness[0];
                GameManager.instance.haveWanted = saveData.haveWeakness[1];
                GameManager.instance.haveRock = saveData.haveWeakness[2];
                GameManager.instance.haveDrug = saveData.haveWeakness[3];

                GameManager.instance.employKnight = saveData.employTalents[0];
                GameManager.instance.employMercenary = saveData.employTalents[1];
                GameManager.instance.employAcrobat = saveData.employTalents[2];
                GameManager.instance.employAlchem = saveData.employTalents[3];

                GameManager.instance.KnightVisited = saveData.TalentVisited[0];
                GameManager.instance.MercenaryVisited = saveData.TalentVisited[1];
                GameManager.instance.AcrobatVisited = saveData.TalentVisited[2];
                GameManager.instance.AlchemVisited = saveData.TalentVisited[3];

                GameManager.instance.employCommoner = saveData.employCommoner;

                GameManager.instance.getClues = saveData.getClues;
                GameManager.instance.Days = saveData.Days;

                GameManager.instance.TodayVisited = saveData.TodayVisited;
                GameManager.instance.eventAcrobat = saveData.eventAcrobat;
                GameManager.instance.eventAlchem = saveData.eventAlchem;

                SceneManager.LoadScene("MainScene");
            }
        }
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        saveData.gold = GameManager.instance.playerGold;
        saveData.atmosphere = GameManager.instance.townAtmosphere;
        saveData.dead = GameManager.instance.townDead;

        saveData.haveWeakness[0] = GameManager.instance.haveDismissal;
        saveData.haveWeakness[1] = GameManager.instance.haveWanted;
        saveData.haveWeakness[2] = GameManager.instance.haveRock;
        saveData.haveWeakness[3] = GameManager.instance.haveDrug;

        saveData.employTalents[0] = GameManager.instance.employKnight;
        saveData.employTalents[1] = GameManager.instance.employMercenary;
        saveData.employTalents[2] = GameManager.instance.employAcrobat;
        saveData.employTalents[3] = GameManager.instance.employAlchem;

        saveData.TalentVisited[0] = GameManager.instance.KnightVisited;
        saveData.TalentVisited[1] = GameManager.instance.MercenaryVisited;
        saveData.TalentVisited[2] = GameManager.instance.AcrobatVisited;
        saveData.TalentVisited[3] = GameManager.instance.AlchemVisited;

        saveData.employCommoner = GameManager.instance.employCommoner;

        saveData.getClues = GameManager.instance.getClues;
        saveData.Days = GameManager.instance.Days;

        saveData.TodayVisited = GameManager.instance.TodayVisited;
        saveData.eventAcrobat = GameManager.instance.eventAcrobat;
        saveData.eventAlchem = GameManager.instance.eventAlchem;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);

        Debug.Log("저장 완료");
        Debug.Log(json);
    }
}
