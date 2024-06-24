using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AuraUI : MonoBehaviour
{
    [SerializeField] IntValue aura;
    TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Aura: "+aura.value;
    }
}
