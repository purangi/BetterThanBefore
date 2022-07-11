using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CSHouseClick : MonoBehaviour
{
    private Image FirstImage; //기존 이미지
    public Sprite nextImage; //변경 테두리 이미지
    public Sprite basicImage; //기본 테두리 이미지
    public string sceneName; //씬 이름

    // Start is called before the first frame update
    void Start()
    {
        FirstImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeImage()
    {
        FirstImage.sprite = nextImage; //마우스 오버시 테두리 이미지 출력
    }

    public void BasicImage()
    {
        FirstImage.sprite = basicImage; //마우스 나갔을때
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
