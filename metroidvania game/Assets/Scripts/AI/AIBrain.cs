using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBrain : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed;
    private float speed;
    private GameObject player;
    [SerializeField]
    private int damage;
    protected GameObject Player
    {
        get { return player; }
        set
        {
            if(value.CompareTag("Player"))
            {
                player = value;
            }
        }
    }
    protected float Speed
    {
        get { return speed; }
        set
        {
            if(value<=maxSpeed)
            {
                speed=value;
            }
            else
            {
                speed = maxSpeed;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
