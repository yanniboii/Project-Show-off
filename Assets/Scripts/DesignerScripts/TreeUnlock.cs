using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreeUnlock : MonoBehaviour
{
    public TMP_Text score;
    public GameObject successPlatform;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        score.text = this.transform.childCount.ToString();
        if (this.transform.childCount <= 0)
        {
            successPlatform.SetActive(true);
            score.enabled = false;
        }
    }
}
