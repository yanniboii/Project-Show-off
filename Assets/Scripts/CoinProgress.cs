using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinProgress : MonoBehaviour
{
    int coinProgress = 0;
    public Slider coinProgressSlider;
    bool fadeOut;
    public Image background;
    public Image fill;
    bool allowedToFade;
    private void Update()
    {
        if (fadeOut)
        {
            background.color = new Color(1f, 1f, 1f, background.color.a - 0.01f);
            fill.color = new Color(1f, 1f, 1f, fill.color.a - 0.01f);
        }
    }
    public void UpdateProgress()
    {
        fadeOut = false;
        background.color = new Color(1f, 1f, 1f, 1f);
        fill.color = new Color(1f, 1f, 1f, 1f);
        coinProgress++;
        coinProgressSlider.value = coinProgress;
        allowedToFade = false;
        StartCoroutine(fading());
    }

    IEnumerator fading()
    {
        allowedToFade = true;
        yield return new WaitForSeconds(4);
        if (allowedToFade)
        {
            fadeOut = true;
        }
    }
}
