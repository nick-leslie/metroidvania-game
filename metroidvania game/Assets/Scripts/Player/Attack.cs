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
    private float vertical;
    private float horizontal;
    private Rigidbody2D rb;
    [SerializeField]
    private bool canatack = true;
    [SerializeField]
    private GameObject slash;
    [SerializeField]
    private int dammage;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //------------------------------------
        //target finding
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (canatack == true)
        {
            if (vertical != 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    target(vertical, Vector2.up, "ver");
                }
            }
            else if (horizontal != 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    target(horizontal, Vector2.right, "hor");
                }
            }
        }
        if (slash.active == true)
        {
            StartCoroutine(attackWait());
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
               if(enmeystoDamage[i].gameObject.GetComponent<AIBrain>() != null)
                {
                    enmeystoDamage[i].gameObject.GetComponent<AIBrain>().takeDamage(dammage);
                }
            }
            backforce(vec, dire);
            canatack = false;
        }
    }
/// <summary>
/// force in the posidt direction
/// </summary>
private void backforce(Vector3 vectorDirection, float type)
{
    RaycastHit2D hit = Physics2D.Raycast(transform.position, vectorDirection * type, Mathf.Infinity, whattohit);
    Debug.DrawRay(transform.position, vectorDirection * type, color: Color.blue, radis);
    if (hit.collider != null)
    {
        rb.velocity = Vector3.zero;
        Vector3 hitpos = new Vector3(hit.point.x, hit.point.y, transform.position.z);
        Vector2 dire = transform.position - hitpos;
        rb.AddRelativeForce(dire.normalized * force);
    }
}
//-------------------------------
/// <summary>
/// sets the dirdection of the slash
/// </summary>
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
    if (vertical != 0)
    {
        Gizmos.DrawWireSphere(transform.position + (Vector3.up * vertical), radis);
    }
    else if (horizontal != 0)
    {
        Gizmos.DrawWireSphere(transform.position + (Vector3.right * horizontal), radis);
    }
}
}

