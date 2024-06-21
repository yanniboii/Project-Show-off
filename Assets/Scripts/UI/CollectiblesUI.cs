using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectiblesUI : MonoBehaviour
{
    [SerializeField] TMP_Text m_Text;
    [SerializeField] IntValue collectedCount;
    [SerializeField] IntValue maxColleclibles;
    // Start is called before the first frame update
    void Start()
    {
        maxColleclibles.value = FindObjectsOfType<OnCollect>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        m_Text.text = collectedCount.value + " / " + maxColleclibles.value;
    }
}
