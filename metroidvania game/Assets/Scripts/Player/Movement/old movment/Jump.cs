using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Jump : MonoBehaviour
{
   // [SerializeField]
    //private float jumpForce;
    [SerializeField]
    private float fallMultiplayer=2.5f;
    [SerializeField]
    private float LowJumpMultiplyer=2;
    Rigidbody2D rb;
    [SerializeField]
    private GameObject dustPartical;
    [SerializeField]
    private Transform particalSpawnPos;
    public bool canJump=true;
    [SerializeField]
    //private float maxjumpVelocity;
    public bool fastFallToggle;
    private float gravity;
    private float jumpVelocity;
    //--------------------------
    // sebastian leuge code
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float timeToJumpApex;
    //--------------------------
    public bool IsGrounded;
    PlayerControls Input;
    [SerializeField]
    private float jumpInput;
    //---------------------------
    public float jumpDeteionRad;
    public LayerMask ground;
    //--------------------------
    public float timeTillFall;
    private float jumpTime;
    //--------------------------
    private void Awake()
    {
        Input = new PlayerControls();
        Input.controls.jump.performed += ctx => jumpInput = ctx.ReadValue<float>();
    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    // Update is called once per frame
    void Update()
    {
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        if (fastFallToggle ==false)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && jumpInput < 1)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMultiplyer - 1) * Time.deltaTime;
            }
        }
        if(Physics2D.OverlapCircle(particalSpawnPos.position, jumpDeteionRad, ground) != null)
        {
            IsGrounded = true;
        }else
        {
            IsGrounded = false;
        }
        if (IsGrounded)
        {
            canJump = true;
            jumpTime = 0;
        }
    }
    void FixedUpdate()
    {
        if (jumpInput > 0)
        {
            if (canJump)
            {
               // rb.velocity = Vector2.up * jumpForce;
                 rb.velocity = new Vector2(rb.velocity.x,jumpVelocity);
                // rb.AddForce(Vector2.up * jumpVelocity,ForceMode2D.Impulse);
                //  rb.velocity = new Vector2(rb.velocity.x, 0);
                // rb.velocity += Vector2.up * jumpForce;
                //rb.AddForce(transform.TransformDirection(Vector3.up) * Time.deltaTime * jumpForce, ForceMode2D.Impulse);
                StartCoroutine(disablJump());
                canJump = false;
            }
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    gameObject.GetComponent<CammraShake>().enabled = true;
    //    IsGrounded = true;
    //    Instantiate(dustPartical, transform.position, transform.rotation);
    //    canJump = true;
    //}
    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    IsGrounded = false;
    //}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(particalSpawnPos.position, jumpDeteionRad);
    }
    private void OnEnable()
    {
        Input.Enable();
    }
    private void OnDestroy()
    {
        Input.Disable();
    }
    IEnumerator disablJump()
    {
        Debug.Log("triped corouten");
        while (jumpTime < timeTillFall)
        {
            yield return new WaitForSeconds(0.5f);
            jumpTime+=0.5f;
        }
        Debug.Log("exeitid while loop");
        jumpInput = 0;
    }

}
