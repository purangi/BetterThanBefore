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

    /*������ ȹ�� ��.. (�� �ּ�ó���� �̿� �ʿ��� ��)
    public void GotItem(ȹ���� ������) {
    if ( items.Count < slots.Length ) {
    items.Add(������);
    } else {
    print("�κ��丮�� �� á���ϴ�.");
    }
    }*/

}
