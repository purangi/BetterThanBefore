using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSInvenManager : MonoBehaviour
{
    //public List<CSInvenManager> items;
    private GameObject InvenObject;
    // public GameObject[] slots;

    // Start is called before the first frame update
    void Start()
    {
        InvenObject = GameObject.Find("Inventory");
        InvenObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*아이템 획득 시.. (위 주석처리도 이에 필요한 것)
    public void GotItem(획득한 아이템) {
    if ( items.Count < slots.Length ) {
    items.Add(아이템);
    } else {
    print("인벤토리가 꽉 찼습니다.");
    }
    }*/

}
