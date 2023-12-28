using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeeffect : MonoBehaviour
{
    private Image image;
    double timer;
    int waitingTime;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        timer = 0.0;
        waitingTime = 11;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > waitingTime){
            Color color = image.color;

            if(color.a > 0)
            {
                color.a -= Time.deltaTime;
            }

            image.color = color;
        }
    }
}
