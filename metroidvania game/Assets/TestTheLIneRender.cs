using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTheLIneRender : MonoBehaviour
{
    private LineRenderer renderer;
    private Transform endPoint;
    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<LineRenderer>();
        renderer.SetPosition(0, transform.position);
        endPoint = GameObject.Find("end point test ").transform;
    }

    // Update is called once per frame
    void Update()
    {
        renderer.SetPosition(0, transform.localPosition);
        renderer.SetPosition(1, endPoint.localPosition);
    }
}
