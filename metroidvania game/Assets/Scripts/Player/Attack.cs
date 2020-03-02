using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private float radis;
    [SerializeField]
    private LayerMask whattohit;
    [SerializeField]
    private float force;
    private Vector3 pos;
    [SerializeField]
    private Vector2 AttackDire;
    private Rigidbody2D rb;
    [SerializeField]
    private bool canatack = true;
    [SerializeField]
    private GameObject slash;
    [SerializeField]
    private int dammage;
    PlayerControls control;
    [SerializeField]
    private float deadzone;
    private float lastDire;
    CharicterControlerBace controler;
    Player p;
    public float forceAplydTime;
    // this varuable is for further keeping track of last input for nutral press cases
    //true is for up and false is for down 
    private bool lrudDire;
    private void Awake()
    {
        control = new PlayerControls();
        control.controls.attack.performed += Attack_Performed;
        control.controls.Move.performed += ctx => AttackDire = ctx.ReadValue<Vector2>().normalized;

    }

    // Start is called before the first frame update
    void Start()
    {
        controler = gameObject.GetComponent<CharicterControlerBace>();
        p = gameObject.GetComponent<Player>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slash.active == true)
        {
            StartCoroutine(attackWait());
        }
    }

    void Attack_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //------------------------------------
        //target finding
        if (canatack == true)
        {
            if (PauseMenu.gameIsPaused == false)
            {
                if (AttackDire.y > deadzone || AttackDire.y < -deadzone)
                {
                    target(AttackDire.y, Vector2.up, "ver");
                    lastDire = AttackDire.y;
                    lrudDire = true;
                }
                else if (AttackDire.x > deadzone || AttackDire.x < -deadzone)
                {
                    target(AttackDire.x, Vector2.right, "hor");
                    lastDire = AttackDire.x;
                    lrudDire = false;
                }
                else
                {
                    Vector3 goodVec;
                    string goodString;
                    if (lrudDire)
                    {
                        goodVec = Vector3.up;
                        goodString = "ver";
                    }
                    else
                    {
                        goodVec = Vector3.right;
                        goodString = "hor";
                    }
                    target(lastDire, goodVec, goodString);
                }
            }
        }
    }


    private IEnumerator attackWait()
    {
        yield return new WaitUntil(() => slash.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("wait") == true);
        canatack = true;
    }

    private void target(float dire, Vector3 vec, string state)
    {
        slashdire(state, dire);
        Collider2D[] enmeystoDamage = Physics2D.OverlapCircleAll(transform.position + (vec * dire), radis, whattohit);
        if (enmeystoDamage.Length > 0)
        {
            for (int i = 0; i < enmeystoDamage.Length; i++)
            {
                if (enmeystoDamage[i].gameObject.GetComponent<AIBrain>() != null)
                {
                    enmeystoDamage[i].gameObject.GetComponent<AIBrain>().takeDamage(dammage);
                }
            }
            StartCoroutine(backforce(vec, dire));
            canatack = false;
        }
    }
    /// <summary>
    /// force in the posidt direction
    /// </summary>
    private IEnumerator backforce(Vector3 vectorDirection, float type)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, vectorDirection * type, Mathf.Infinity, whattohit);
        Debug.DrawRay(transform.position, vectorDirection * type, color: Color.blue, radis);
        if (hit.collider != null)
        {
            rb.velocity = Vector3.zero;
            for (int i = 0; i < forceAplydTime; i++)
            {
                p.velocity = ((AttackDire * vectorDirection)*-1) * force * Time.deltaTime;
                Debug.Log(vectorDirection);
                p.applyGrav = false;
                controler.Move(p.velocity);
                yield return new WaitForSeconds(0.1f);
                p.applyGrav = true;
            }
        }
    }
    //-------------------------------
    // <summary>
    // sets the dirdection of the slash
    // </summary>
    private void slashdire(string state, float dire)
    {
        if (state == "ver")
        {
            if (dire > 0)
            {
                slashcode(90);
            }
            else if (dire < 0)
            {
                slashcode(270);
            }
        }
        else if (state == "hor")
        {
            if (dire > 0)
            {
                slashcode(0);
            }
            else if (dire < 0)
            {
                slashcode(180);
            }
        }

    }
    /// <summary>
    /// exsacutes the slash
    /// </summary>
    private void slashcode(float angle)
    {
        if (slash.activeSelf == false)
        {
            slash.SetActive(true);
        }
        else
        {
            slash.GetComponent<Animator>().SetBool("active", true);
        }
        slash.transform.rotation = Quaternion.Euler(0, 0, angle);
        slash.GetComponent<Animator>().SetBool("active", false);
        StartCoroutine(waitTillAnimDone());
    }
    /// <summary>
    /// Waits  till animation done.
    /// </summary>
    private IEnumerator waitTillAnimDone()
    {

        yield return new WaitUntil(() => slash.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("wait") == true);
        slash.SetActive(false);
    }
    //----------------------------------
    /// <summary>
    /// Ons the draw gizmos selected.
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (AttackDire.y != 0)
        {
            Gizmos.DrawWireSphere(transform.position + (Vector3.up * AttackDire.y), radis);
        }
        else if (AttackDire.x != 0)
        {
            Gizmos.DrawWireSphere(transform.position + (Vector3.right * AttackDire.x), radis);
        }

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

