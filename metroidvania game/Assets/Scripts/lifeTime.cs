using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeTime : MonoBehaviour
{
    [SerializeField]
    private float Life;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("die", Life);
    }
   private void die()
    {
        Destroy(gameObject);
    }
}
