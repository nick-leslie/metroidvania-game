using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpStar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) 
        {
            other.gameObject.GetComponent<Jump>().canJump = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Jump>().canJump = true;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            StartCoroutine(WaitAsecond());
        }
    }
    private IEnumerator WaitAsecond()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
