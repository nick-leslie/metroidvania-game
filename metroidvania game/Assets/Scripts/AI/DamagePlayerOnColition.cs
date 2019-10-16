using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DamagePlayerOnColition : MonoBehaviour
{
    private AIBrain brain;
    // Start is called before the first frame update
    void Start()
    {
        brain = gameObject.GetComponent<AIBrain>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player"))
        {
            other.collider.GetComponent<HealthMainiger>().Health -= 1;
            Vector3 dire = other.gameObject.transform.position - gameObject.transform.position;
            // Ray2D dire = new Ray2D(transform.position, other.transform.position);
            //  other.rigidbody.velocity = Vector2.zero;
            // Debug.Log(dire);
            // other.transform.position =Vector3.MoveTowards(other.transform.position,dire * brain.KnockBack, brain.KnockbackDuration);
            other.rigidbody.AddForce(dire.normalized * -500f);
        }
    }
}
