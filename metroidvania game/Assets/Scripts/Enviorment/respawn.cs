using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class respawn : MonoBehaviour
{
    [SerializeField]
    private Transform spawnpos;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        spawnpos = GameObject.FindWithTag("lastGroundPos").transform;
        if (other.CompareTag("Player")) 
        {
            HealthMainiger temphealth = other.GetComponent<HealthMainiger>();
            if (temphealth.Health>0)
            {
                temphealth.Health -= 1;
                other.transform.position = new Vector3(spawnpos.position.x,spawnpos.position.y,other.transform.position.z);
            }
            if(temphealth.Health==0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
