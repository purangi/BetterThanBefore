using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueOver : MonoBehaviour
{
    public GameObject Message;
    public GameObject slot;

    public void ShowMessage()
    {
        Item item = slot.GetComponent<Slot>().item;

        if(item != null)
        {
            Message.SetActive(true);
        }
    }

    public void CloseMessage()
    {
        Message.SetActive(false);
    }
}
