using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHButton : MonoBehaviour
{
    public Texture2D cursorTextureA;
    public Texture2D cursorTextureB;
    public bool IsCursorCandle;

    private Vector2 hotSpot;

    private GameObject candleObject;
    private GameObject keyObject;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetCandle() //커서 변경
    {
        candleObject = GameObject.Find("KHCandle"); //촛불 오브젝트
        candleObject.SetActive(false);

        hotSpot.x = cursorTextureA.width / 2;
        hotSpot.y = cursorTextureA.height / 2;
       
        Cursor.SetCursor(cursorTextureA, hotSpot, CursorMode.ForceSoftware);
        IsCursorCandle = true;
    }

    public void GetKey() //열쇠 얻기
    {
        keyObject = GameObject.Find("KHKey"); //열쇠 오브젝트

        hotSpot.x = cursorTextureB.width / 2;
        hotSpot.y = cursorTextureB.height / 2;

        Cursor.SetCursor(cursorTextureB, hotSpot, CursorMode.ForceSoftware);
        keyObject.SetActive(false);
    }

    public void OpenDrawer()
    {
        if (GameObject.Find("Canvas").transform.Find("KHKey").gameObject.activeSelf == false) //인벤토리로 연결해야할듯
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            Debug.Log("획득");
        } else
        {
            Debug.Log("실패");
        }
    }
}
