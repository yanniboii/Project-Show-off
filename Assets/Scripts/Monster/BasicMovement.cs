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

    public Player player;
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
            if(jumpInput>0){
                rb.AddForce(new Vector3(0, jumpInput * monsterData.jumpHeight, 0), ForceMode.Impulse);
                grounded = false;
            }
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

    public void OnMove(Vector2 dir)
    {
        moveInput = dir;
    }

    public void OnJump(float jump)
    {

        jumpInput = jump;

    }

    public void BeforeSwap()
    {
        player.beforeMove -= OnMove;
        player.beforeJump -= OnJump;
        moveInput = Vector2.zero;
        jumpInput = 0;
    }

    public void AfterSwap()
    {
        player.beforeMove += OnMove;
        player.beforeJump += OnJump;
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

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}