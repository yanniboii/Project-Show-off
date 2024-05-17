using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
public class BasicMovement : MonoBehaviour
{
    public MonsterData monsterData;
    [SerializeField] bool grounded;

    [HideInInspector]
    public CameraInfo cameraInfo;

    Rigidbody rb;
    Vector2 moveInput;
    float jumpInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveInput.x * monsterData.speed, rb.velocity.y, moveInput.y * monsterData.speed);

        if (grounded)
        {
            rb.AddForce(new Vector3(0,jumpInput*monsterData.jumpHeight,0),ForceMode.Impulse);
            grounded = false;
        }
    }

    private void Update()
    {
        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.x, moveInput.y) * Mathf.Rad2Deg;
            Quaternion moveDir = Quaternion.Euler(0, angle, 0);
            transform.rotation = moveDir;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {

        jumpInput = context.ReadValue<float>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}