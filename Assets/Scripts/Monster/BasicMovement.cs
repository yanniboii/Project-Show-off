using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
public class BasicMovement : MonoBehaviour
{
    public MonsterData monsterData;
    [SerializeField] float grounded;
    [SerializeField] bool bouncing;
    [SerializeField] float rayLength = 1.0f;

    [HideInInspector]
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
        bouncing = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float g = CheckGround();
        if(g>grounded){grounded = g;}else{grounded = Mathf.Max(grounded - 0.5f, g);}
        rb.velocity = new Vector3(moveInput.x * monsterData.speed, rb.velocity.y, moveInput.y * monsterData.speed);

        if (grounded>0)
        {
            if (jumpInput > 0 || bouncing) {
                float b = 0f; if(bouncing){b = 0.6f;}
                float i = 0f; if(jumpInput>0){i = 1f;}
                float mx = Mathf.Max(i,b);
                rb.AddForce(new Vector3(0, mx * monsterData.jumpHeight, 0), ForceMode.Impulse);
                grounded = 0f;
            }
        } else {
            if (jumpInput <= 0) {
                rb.AddForce(new Vector3(0, -extraGravity, 0));

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

    private float CheckGround()
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
            if (hit.collider.CompareTag("Ground")){
                bouncing = false;
                return 1f;
            }else
            if (hit.collider.CompareTag("Bouncy")){
                bouncing = true;
                return 1f;
            }
        }
        bouncing = false;
        return (0f);

    }

}