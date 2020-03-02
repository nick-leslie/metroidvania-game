using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharicterControlerBace))]
public class Player : MonoBehaviour
{
    public float maxJumpHight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    public float gravidy { get; set; }
    
    CharicterControlerBace controler;
    PlayerControls control;
    public Vector2 moveInput;

    float minJumpVelocity;
    float MaxJumpVelocity;
    public Vector3 velocity;
    [SerializeField]

    public float moveSpeed;
    public bool applyGrav=true;
    float velocityXsmothing;
    private void Awake()
    {
        control = new PlayerControls();
        control.controls.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>().normalized;
    }
    // Start is called before the first frame update
    private void Start()
    {
        gravidy = -(2 * maxJumpHight) / Mathf.Pow(timeToJumpApex, 2);
        MaxJumpVelocity = Mathf.Abs(gravidy) * timeToJumpApex;
        minJumpHeight = Mathf.Sqrt(2 * Mathf.Abs(gravidy) * minJumpHeight);
        controler = gameObject.GetComponent<CharicterControlerBace>();
    }

    // Update is called once per frame
    void Update()
    {
        gravidy = -(2 * maxJumpHight) / Mathf.Pow(timeToJumpApex, 2);
        MaxJumpVelocity = Mathf.Abs(gravidy) * timeToJumpApex;
        if (controler.colinfo.above || controler.colinfo.bellow)
        {
            velocity.y = 0;
        }
        if (moveInput.y > 0 && controler.colinfo.bellow)
        {
            velocity.y = MaxJumpVelocity;
        }
        //TODO fix this so its not using old input system
        if(Input.GetKeyUp(KeyCode.W))
        {
            if (velocity.y > minJumpVelocity)
            {
                velocity.y = minJumpVelocity;
            }
        }

        float TargetvelocityX = moveInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, TargetvelocityX, ref velocityXsmothing, (controler.colinfo.bellow) ? accelerationTimeGrounded : accelerationTimeAirborne);
        if (applyGrav==true)
        {
            velocity.y += gravidy * Time.deltaTime;
        }
        controler.Move(velocity * Time.deltaTime);
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
