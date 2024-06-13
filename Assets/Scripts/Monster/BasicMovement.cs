using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
public class BasicMovement : MonoBehaviour
{
    public MonsterData monsterData;
    [SerializeField] bool glide = false;
    bool grounded;
    [SerializeField] float rayLength = 1.0f;

    public CameraInfo cameraInfo;

    public Player player;
    Rigidbody rb;
    Vector2 moveInput;
    float jumpInput;
    [SerializeField] float extraGravity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = CheckGround();
        rb.velocity = new Vector3(moveInput.x * monsterData.speed, rb.velocity.y, moveInput.y * monsterData.speed);

        if (grounded)
        {
            if (jumpInput > 0) {
                rb.AddForce(new Vector3(0, jumpInput * monsterData.jumpHeight, 0), ForceMode.Impulse);
                grounded = false;
                rb.useGravity = true;

            }
        } else {
            if (jumpInput < 1) {
                rb.AddForce(new Vector3(0, -extraGravity, 0));
                rb.useGravity = true;
            }
            else if(glide)
            {
                rb.useGravity = false;
                rb.AddForce((Physics.gravity * rb.mass)/20f);
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

    private bool CheckGround()
    {
        // Origin of the raycast is at the position of the GameObject this script is attached to
        Vector3 origin = transform.position;

        // Direction of the raycast is downward (negative y direction)
        Vector3 direction = Vector3.down;

        // For visual debugging, draw the ray in the scene view
        Debug.DrawRay(origin, direction * rayLength, Color.red);
        // Perform the raycast
        if (Physics.Raycast(origin, direction, out RaycastHit hit, rayLength))
        {
            return true;
        }
        return (false);

    }

    //void OnCollisionStay(Collision collision)
    //{
    //    if (collision.transform.CompareTag("Ground"))
    //    {
    //        Debug.Log("c");
    //        grounded = true;
    //    }
    //}
}