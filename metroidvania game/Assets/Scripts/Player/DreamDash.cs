using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamDash : MonoBehaviour
{
    // controls 
    PlayerControls control;
    private float dire;
    //manigment
    private Rigidbody2D rb;
    [SerializeField]
    private float dashDistence;
    private bool dash=false;
    [SerializeField]
    private float dashTime;
    private float grav;
    private float storedDrie;
    [SerializeField]
    private float CoolDown;
    private bool CanDash=true;
    //commbat
    [SerializeField]
    private Vector2 HitBoxSize;
    [SerializeField]
    private int Damage;
    private List<GameObject> enemys = new List<GameObject>();
    //geting componets
    private Movement move;
    private HealthMainiger hp;
    private void Awake()
    {
        control = new PlayerControls();
        control.controls.DreamDash.performed += DreamDash_Performed;
        control.controls.Move.performed += ctx => dire= ctx.ReadValue<Vector2>().x;

    }
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        grav = 1;
        move = gameObject.GetComponent<Movement>();
        hp = gameObject.GetComponent<HealthMainiger>();

    }
    void DreamDash_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (CanDash)
        {
            StartCoroutine(Dashing());
            if (storedDrie == 0)
            {
                storedDrie = dire;
            }
            CanDash = false;
            StartCoroutine(cooling());
        }
    }
    private void Update()
    {
        if (dash)
        {
            rb.velocity = Vector2.zero;
            transform.Translate(storedDrie*dashDistence * Time.deltaTime, 0, 0);
            Collider2D[] enemysToDmg = Physics2D.OverlapBoxAll(transform.position + (storedDrie * Vector3.right), HitBoxSize, 0);
            for (int i = 0; i < enemysToDmg.Length; i++)
            {
                if(enemysToDmg[i].CompareTag("Enemy"))
                {
                    enemysToDmg[i].gameObject.GetComponent<AIBrain>().takeDamage(Damage);
                    enemysToDmg[i].gameObject.GetComponent<AIBrain>().tookDmg=true;
                    enemys.Add(enemysToDmg[i].gameObject);
                }
            }
        }
    }
    IEnumerator Dashing()
    {
        rb.gravityScale = 0;
        dash = true;
        move.enabled = false;
        hp.Invincibal = true;
        yield return new WaitForSeconds(dashTime);
        storedDrie = 0;
        move.enabled = true;
        hp.Invincibal = false;
        rb.gravityScale = grav;
        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i] != null)
            {
                enemys[i].gameObject.GetComponent<AIBrain>().tookDmg = false;
            }
        }
        enemys.Clear();
        dash = false;
    }
    IEnumerator cooling()
    {
        yield return new WaitForSeconds(CoolDown);
        CanDash = true;
    }

    private void OnEnable()
    {
        control.Enable();
    }
    private void OnDisable()
    {
        control.Disable();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.localPosition + (storedDrie * Vector3.right), HitBoxSize);
    }
}
