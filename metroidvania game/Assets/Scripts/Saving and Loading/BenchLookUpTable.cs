using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BenchLookUpTable : MonoBehaviour
{
   public Dictionary<int, Transform> benches = new Dictionary<int, Transform>();
    private GameObject[] benchesFound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
