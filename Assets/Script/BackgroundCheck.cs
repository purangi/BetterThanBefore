using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCheck : MonoBehaviour
{
    public SpriteRenderer img_render;
    public Sprite origin;
    public Sprite bad1;
    public Sprite bad2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.townAtmosphere > 30 && GameManager.Instance.townAtmosphere <= 50)
        {
            img_render.sprite = bad1;
        } else if(GameManager.Instance.townAtmosphere > 50)
        {
            img_render.sprite = bad2;
        } else
        {
            img_render.sprite = origin;
        }
    }
}
