using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerDiscover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetJoystickNames().Length > 0) 
        {
            Debug.Log("testig");
        }
        else
        {
            Debug.Log("shit");
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
