using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class findCamra : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
