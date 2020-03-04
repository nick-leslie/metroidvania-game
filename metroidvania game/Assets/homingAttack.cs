using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingAttack : MonoBehaviour
{
    [SerializeField]
    private int lifeTime;
    [SerializeField]
    private int speed;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
      
        StartCoroutine(deathTime());
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position,player.transform.position,speed);
        } else
        {
           // Destroy(gameObject);
        }
    }
    IEnumerator deathTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
