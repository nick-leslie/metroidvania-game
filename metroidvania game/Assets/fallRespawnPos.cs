using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallRespawnPos : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private float groundDis;
    private Vector3 lastSafePos;
    [SerializeField]
    private LayerMask whatTOhit;
    [SerializeField]
    private float recoredDelay;
    private RaycastHit2D ray;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
         ray = Physics2D.Raycast(transform.position, -Vector3.up, groundDis,whatTOhit);
        if (player.GetComponent<Jump>().IsGrounded == false)
        {
            transform.position = lastSafePos + Vector3.up;
            transform.parent = null; 

        }
        else
        {
            transform.parent = player.transform;
            transform.position = player.transform.position;
            Debug.DrawRay(transform.position, -Vector3.up,color:Color.red);
            if (ray.collider != null)
            {
                lastSafePos = ray.point;
            }
            Debug.Log(lastSafePos);

        }
    }
}
