using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] GameObject followObject;

    public delegate void BeforeSwapCharacter(GameObject go);
    public static BeforeSwapCharacter beforeSwapCharacter;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapCharacter(InputAction.CallbackContext context)
    {
        Debug.Log("A");

        beforeSwapCharacter.Invoke(gameObject);
    }
}
