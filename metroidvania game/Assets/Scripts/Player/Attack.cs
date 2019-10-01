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
    private float startTimeBtwAttack;
    private float workingTimeBtwAttack;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        workingTimeBtwAttack = startTimeBtwAttack;
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        if (workingTimeBtwAttack <= 0)
        {
            if (vertical != 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Collider2D[] enmeystoDamage = Physics2D.OverlapCircleAll(transform.position + (Vector3.up * vertical), radis,whattohit);
                    if (enmeystoDamage.Length > 0) {
                        for (int i = 0; i < enmeystoDamage.Length; i++)
                        {
                         //todo
                        }
                        backforce(Vector3.up, vertical);
                        workingTimeBtwAttack = startTimeBtwAttack;
                    }
                }
            }
            else if (horizontal != 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Collider2D[] enmeystoDamage = Physics2D.OverlapCircleAll(transform.position + (Vector3.right * horizontal), radis,whattohit);
                    if (enmeystoDamage.Length > 0)
                    {
                        for (int i = 0; i < enmeystoDamage.Length; i++)
                        {
                            //todo
                        }
                        backforce(Vector3.right, horizontal);
                        workingTimeBtwAttack = startTimeBtwAttack;
                    }
                }
            }
        }
        else
        {
            workingTimeBtwAttack -= Time.deltaTime;
        }
    }
    private void backforce(Vector3 vectorDirection,float type)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, vectorDirection * type, Mathf.Infinity, whattohit);
        Debug.DrawRay(transform.position, vectorDirection * type,color:Color.blue,radis);
        if (hit.collider != null)
        {
            rb.velocity = Vector3.zero;
            Vector3 hitpos = new Vector3(hit.point.x, hit.point.y, transform.position.z);
            Vector2 dire = transform.position - hitpos;
            rb.AddRelativeForce(dire.normalized * force);
        }
    }
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
