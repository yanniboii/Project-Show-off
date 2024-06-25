using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public GameObject followObject;
    [SerializeField] float SwapCooldown;
    public IntValue aura;

    [HideInInspector]
    public CameraInfo cameraInfo;

    #region events
    public delegate GameObject BeforeSwapCharacter(GameObject go);
    public static BeforeSwapCharacter beforeSwapCharacter;

    public delegate void BeforeMove(Vector2 dir);
    public BeforeMove beforeMove;

    public delegate void BeforeJump(float jump);
    public BeforeJump beforeJump;

    public delegate void BeforeAbility();
    public BeforeAbility beforeAbility;

    public delegate void BeforeRotate(Vector2 dir);
    public BeforeRotate beforeRotate;
    #endregion

    bool canSwap = true;
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
        if (canSwap && followObject != null)
        {
            StartCoroutine(WaitFor());
            followObject = beforeSwapCharacter?.Invoke(followObject);
        }
    }

    public void OnBeforeMove(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        Debug.Log(dir.magnitude);
        if(!(dir.magnitude <= -0.3f || dir.magnitude >= 0.3f))
        {
            dir = Vector2.zero;
        }
        Vector3 forward = cameraInfo.brain.gameObject.transform.forward;
        Vector3 right = cameraInfo.brain.gameObject.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();
        Vector3 combinedMovement = forward * dir.y +right * dir.x;

        beforeMove?.Invoke(new Vector2(combinedMovement.x,combinedMovement.z));
    }

    public void OnBeforeJump(InputAction.CallbackContext context)
    {
        beforeJump?.Invoke(context.ReadValue<float>());
    }

    public void OnBeforeAbility(InputAction.CallbackContext context)
    {
        beforeAbility?.Invoke();
    }

    public void OnRotateCamera(InputAction.CallbackContext context)
    {
        beforeRotate?.Invoke(context.ReadValue<Vector2>());
    }

    public IEnumerator WaitFor()
    {
        canSwap = false;
        yield return new WaitForSeconds(SwapCooldown);
        canSwap = true;
    }
}
