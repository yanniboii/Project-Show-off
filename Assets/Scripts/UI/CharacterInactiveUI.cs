using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterInactiveUI : MonoBehaviour
{
    [SerializeField] PlayerManager manager;
    [SerializeField] int text;
    
    // Start is called before the first frame update
    void Start()
    {
        manager.onCharacterInactive += OnInactive;
        manager.onCharacterActive += OnActive;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnInactive(int i)
    {
        if(i == text-1)
        {
            gameObject.GetComponent<TMP_Text>().enabled = false;
        }

    }

    void OnActive(int i) 
    {
        if (i == text - 1)
        {
            Debug.Log("A");
            gameObject.GetComponent<TMP_Text>().enabled = true;
        }

    }

}
