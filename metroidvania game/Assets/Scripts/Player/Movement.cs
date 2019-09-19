using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    protected float playerInput;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float walkspeed;
    private float movespeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = Input.GetAxis("Horizontal");
        movespeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkspeed;

        rb.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") * movespeed* Time.deltaTime,rb.velocity.y);
    }
}
