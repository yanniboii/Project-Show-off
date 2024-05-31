using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public string nextLevel;
    public Image blackOut;
    bool dimming;
    float i;
    private void Awake()
    {
        dimming = false;
        blackOut.color = new Color(0f, 0f, 0f, 0f);
        i = 0;
    }

    private void Update()
    {
        if (dimming)
        {
            i += 0.015f;
            blackOut.color = new Color(0, 0, 0, i);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (nextLevel != null && collision.gameObject.tag == "Player")
        {
            Debug.Log(nextLevel);
            dimming = true;
            i = 0;
        } 
    }
}
