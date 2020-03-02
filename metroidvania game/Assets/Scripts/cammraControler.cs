using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammraControler : MonoBehaviour
{
    private Transform player;
    public float smoothTime;
    public Vector3 offset; 
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
       Vector3 desiredPosition = player.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPosition, smoothTime);

        transform.position = smoothPos; 
    }
    
    
}
