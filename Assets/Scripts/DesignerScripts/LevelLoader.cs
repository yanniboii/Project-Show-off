using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Vector3 nextLevel;
    public Image blackOut;
    GameObject collidedPlayer;
    bool oneTimeTrigger = true;
    private void Awake()
    {
        blackOut.color = new Color(0f, 0f, 0f, 0f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (nextLevel != null && collision.gameObject.tag == "Player" && oneTimeTrigger)
        {
            oneTimeTrigger = false;
            collidedPlayer = collision.gameObject;
            collidedPlayer.transform.position = nextLevel;
            //StartCoroutine(FadeOut());
        } 
    }

    IEnumerator FadeIn()
    {
        collidedPlayer.transform.position = nextLevel;
        float transparency = 1;
        oneTimeTrigger = true;
        for (int i = 0; i < 50; i++)
        {
            transparency -= 0.02f;
            blackOut.color = new Color(0, 0, 0, transparency);
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }

    IEnumerator FadeOut()
    {
        Debug.Log("FadingOut");
        float transparency = 0;
        for (int i = 0; i < 50; i ++)
        {
            transparency += 0.02f;
            blackOut.color = new Color(0, 0, 0, transparency);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        yield return new WaitForSecondsRealtime(1f);
        StartCoroutine(FadeIn());
    }
}
