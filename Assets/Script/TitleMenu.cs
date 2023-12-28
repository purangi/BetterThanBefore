using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool("isMouseEnter", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool("isMouseEnter", false);
    }

    public void GameStart()
    {
        //���� ����
        SceneManager.LoadScene("MainScene");
    }

    public void GameExit()
    {
        //���� ���� -> �� ����?
        Application.Quit();
    }
}
