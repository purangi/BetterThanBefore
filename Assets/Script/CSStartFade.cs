using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSStartFade : MonoBehaviour
{
    private Image Fade;

    private void Awake()
    {
        Fade = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine("FadeOut");
    }

    private IEnumerator FadeOut()
    {
        for (float f = 0f; f < 0.6f; f += 0.003f)
        {
            Color c = Fade.GetComponent<Image>().color;
            c.a = f;
            Fade.GetComponent<Image>().color = c;
            yield return null;
        }
    }

}
