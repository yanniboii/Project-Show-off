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

    [SerializeField] float coyoteTime;
    [SerializeField] bool glide = false;
    [SerializeField] float rayLength = 1.0f;

    bool isWaterWalking = false;
    [SerializeField] bool canWaterWalk = false;

    [SerializeField] Transform animatedObject;
    Vector3 animatedObjectTargetScale = Vector3.one;

    Vector3 lastSafeSpot;

    public CameraInfo cameraInfo;

    public Player player;
    Rigidbody rb;
    Vector2 moveInput;
    float jumpInput;
    [SerializeField] float extraGravity;
    [SerializeField] PlayerAudio mysounds;
    [SerializeField] bool makeFloatingAnim;

    float FloatingInitialY;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bouncing = false;
        lastSafeSpot = transform.position;

        if(makeFloatingAnim){
            FloatingInitialY = animatedObject.localPosition.y;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.useGravity = true;
        float g = CheckGround();
        if(grounded<=0f && g>=1f){animatedObject.localScale = new Vector3(1.3f,0.7f,1.3f);}
        if(g>grounded){grounded = g;}else{grounded = Mathf.Max(grounded - coyoteTime*Time.fixedDeltaTime, g);}
        rb.velocity = new Vector3(moveInput.x * monsterData.speed, rb.velocity.y, moveInput.y * monsterData.speed);

        if (grounded>0)
        {
            if (jumpInput > 0 || bouncing) {
                float b = 0f; if(bouncing){b = 0.6f;}
                float i = 0f; if(jumpInput>0){i = 1f;}
                float mx = Mathf.Max(i,b);
                
                    Vector3 velocity = rb.velocity;
                    velocity.y = 0f;
                    rb.velocity = velocity;
                
                rb.AddForce(new Vector3(0, mx * monsterData.jumpHeight, 0), ForceMode.Impulse);
                
                animatedObject.localScale = new Vector3(0.6f,1.5f*mx*(monsterData.jumpHeight/30),0.6f);
                grounded = 0f;
                
                mysounds.PlayJump();

            }
        } else {
            if (jumpInput <= 0) {
                rb.AddForce(new Vector3(0, -extraGravity, 0));
            }
            else if(glide && rb.velocity.y <0)
            {
                rb.useGravity = false;
                rb.AddForce((Physics.gravity * rb.mass)/20f);
            }
        }
    }

    private void Update()
    {

        // lerp size
        animatedObject.localScale = Vector3.Lerp(animatedObject.localScale, animatedObjectTargetScale, 3f*Time.deltaTime);
        if(makeFloatingAnim){
            animatedObject.localPosition = new Vector3(animatedObject.localPosition.x,FloatingInitialY+Mathf.Sin(Time.time*2f)*0.5f,animatedObject.localPosition.z);
        }


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
                lastSafeSpot = new Vector3(transform.position.x,transform.position.y+1f,transform.position.z);
                bouncing = false;
                isWaterWalking = false;
                return 1f;
            }else
            if (hit.collider.CompareTag("Bouncy")){
                bouncing = true;
                isWaterWalking = false;
                return 1f;
            }else
            if(hit.collider.CompareTag("Water")){
                if(canWaterWalk){
                    bouncing = false;
                    isWaterWalking = true;
                    return 1f;
                }else{
                    GoDead();
                    return 0f;
                }
            }
        }
        bouncing = false;
        isWaterWalking = false;
        return (0f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Depths"))
        {
            GoDead();
        }
    }

    void GoDead () {
        mysounds.PlayDeath();
        transform.position = lastSafeSpot;
    }

    public void Shoot(){
        mysounds.PlayShoot();
        animatedObject.localScale = new Vector3(1.1f,0.8f,1.1f);
    }


}