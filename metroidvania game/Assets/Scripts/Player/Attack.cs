using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObject player;
    private Vector3 angle= new Vector3(0,0,360);
    private bool rotatite = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rotatite = true;
        }
        if(rotatite==true)
        {
            if (transform.rotation.z > 0)
            {
                transform.RotateAround(player.transform.position, angle, 90 * Time.time);
            }
            else
            {
                rotatite = false;

            }
        }
    }
}
