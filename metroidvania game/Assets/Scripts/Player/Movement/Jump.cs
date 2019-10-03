using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool betterjump=true;


    private float gravity;
    private float jumpVelocity;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float timeToJumpApex;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    // Update is called once per frame
    void Update()
    {
        FixedUpdate();
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMultiplyer - 1) * Time.deltaTime;
            }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (canJump)
            {
                rb.velocity = Vector2.up * jumpForce;
               // rb.velocity += Vector2.up *jumpVelocity;
               // rb.AddForce(Vector2.up * jumpVelocity,ForceMode2D.Impulse);
                //  rb.velocity = new Vector2(rb.velocity.x, 0);
                // rb.velocity += Vector2.up * jumpForce;
                canJump = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<CammraShake>().enabled = true;
        Instantiate(dustPartical, transform.position, transform.rotation);
        canJump = true;
    }
}
