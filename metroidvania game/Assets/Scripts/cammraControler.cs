using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammraControler : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x,player.position.y,-10);
    }
}
