using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public GameObject followObject;
    [SerializeField] float SwapCooldown;

    [HideInInspector]
    public CameraInfo cameraInfo;


    public delegate GameObject BeforeSwapCharacter(GameObject go);
    public static BeforeSwapCharacter beforeSwapCharacter;

    public delegate void BeforeMove(Vector2 dir);
    public BeforeMove beforeMove;

    public delegate void BeforeJump(float jump);
    public BeforeJump beforeJump;

    public delegate void BeforeAbility();
    public BeforeAbility beforeAbility;


    bool canSwap = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(followObject != null)
        {
            transform.position = followObject.transform.position;
        }
    }

    public void OnBeforeSwapCharacter(InputAction.CallbackContext context)
    {
        if (canSwap)
        {
            StartCoroutine(WaitFor());
            Debug.Log("A");
            followObject = beforeSwapCharacter?.Invoke(followObject);
        }
    }

    public void OnBeforeMove(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        beforeMove?.Invoke(dir);
    }

    public void OnBeforeJump(InputAction.CallbackContext context)
    {
        beforeJump?.Invoke(context.ReadValue<float>());
    }

    public void OnBeforeAbility(InputAction.CallbackContext context)
    {
        beforeAbility?.Invoke();
    }

    public IEnumerator WaitFor()
    {
        canSwap = false;
        yield return new WaitForSeconds(SwapCooldown);
        canSwap = true;
    }
}
