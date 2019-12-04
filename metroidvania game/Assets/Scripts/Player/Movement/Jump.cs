using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Jump : MonoBehaviour
{
    [SerializeField]
    private float jumpForce;
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
    private float maxjumpVelocity;
    public bool fastFallToggle;
    private float gravity;
    private float jumpVelocity;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float timeToJumpApex;
    public bool IsGrounded;
    PlayerControls Input;
    private float jumpInput;
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
    }
    void FixedUpdate()
    {
        if (jumpInput>0)
        {
            if (canJump)
            {
                rb.velocity = Vector2.up * jumpForce;
                // rb.velocity += Vector2.up *jumpVelocity;
                // rb.AddForce(Vector2.up * jumpVelocity,ForceMode2D.Impulse);
                //  rb.velocity = new Vector2(rb.velocity.x, 0);
                // rb.velocity += Vector2.up * jumpForce;
                //rb.AddForce(transform.TransformDirection(Vector3.up) * Time.deltaTime * jumpForce, ForceMode2D.Impulse);
                canJump = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<CammraShake>().enabled = true;
        IsGrounded = true;
        Instantiate(dustPartical, transform.position, transform.rotation);
        canJump = true;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        IsGrounded = false;
    }
    private void OnEnable()
    {
        Input.Enable();
    }
    private void OnDestroy()
    {
        Input.Disable();
    }
}
