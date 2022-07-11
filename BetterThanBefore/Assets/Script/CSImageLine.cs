using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CSHouseClick : MonoBehaviour
{
    private Image FirstImage; //���� �̹���
    public Sprite nextImage; //���� �׵θ� �̹���
    public Sprite basicImage; //�⺻ �׵θ� �̹���
    public string sceneName; //�� �̸�

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
        FirstImage.sprite = nextImage; //���콺 ������ �׵θ� �̹��� ���
    }

    public void BasicImage()
    {
        FirstImage.sprite = basicImage; //���콺 ��������
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
