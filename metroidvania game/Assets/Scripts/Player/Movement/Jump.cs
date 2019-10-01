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
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FixedUpdate();
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer - 1)  * Time. deltaTime;
        } else if( rb.velocity.y > 0 && !Input.GetKey(KeyCode.W))
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
