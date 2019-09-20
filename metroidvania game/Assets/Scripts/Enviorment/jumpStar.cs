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
            other.gameObject.GetComponent<Jump>().canJump = false;
            Destroy(gameObject);
        }
    }
}
