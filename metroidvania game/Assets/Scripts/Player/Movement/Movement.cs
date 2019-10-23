using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    protected float playerInput;
    [SerializeField] private float sprintSpeedMax;
    [SerializeField] private float sprintIncreceOvertime;
    private float sprintSpeed = 0;
    [SerializeField] private float walkspeed;
    [SerializeField]
    private float movespeed;
    private Rigidbody2D rb;
    PlayerControls control;
    [SerializeField]
    private Vector2 moveInput;
    private float sprintInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sprintSpeed = walkspeed;
        movespeed = walkspeed;
    }
    private void Awake()
    {
        control = new PlayerControls();
        control.controls.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        control.controls.sprint.performed += ctx =>sprintInput= ctx.ReadValue<float>();
    }


    // Update is called once per frame
    void Update()
    {
        playerInput = moveInput.x;
    }
    private void FixedUpdate()
    {
        movespeed = sprintInput>0 ? sprintSpeed += sprintIncreceOvertime * Time.deltaTime : walkspeed;
        if (movespeed > sprintSpeedMax)
        {
            sprintSpeed = sprintSpeedMax;
        }
        if (sprintInput<1)
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
        rb.velocity = new Vector2( playerInput * movespeed * Time.deltaTime, rb.velocity.y);
    }
   

    private void OnEnable()
    {
        control.Enable();
    }
    private void OnDisable()
    {
        control.Disable();
    }
}