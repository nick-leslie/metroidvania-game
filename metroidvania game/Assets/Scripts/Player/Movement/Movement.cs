using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    protected float playerInput;
    [SerializeField] private float sprintSpeedMax;
    [SerializeField] private float sprintIncreceOvertime;
    private float sprintSpeed = 0;
    [SerializeField] private float walkspeed;
    private float movespeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sprintSpeed = walkspeed;
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        movespeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed += sprintIncreceOvertime * Time.deltaTime : walkspeed;
        if (sprintSpeed > sprintSpeedMax)
        {
            sprintSpeed = sprintSpeedMax;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (movespeed > walkspeed)
            {
                sprintSpeed -= sprintIncreceOvertime*Time.deltaTime;
            }
            if(movespeed<walkspeed) 
            {
                sprintSpeed = walkspeed;
            }

        }
        rb.velocity = new Vector2(playerInput * movespeed * Time.deltaTime, rb.velocity.y);
    }
}