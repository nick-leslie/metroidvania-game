using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class BenchInteract : MonoBehaviour
{
    public int benchNumber;
    public int SceneNumber;
    private WorkingPlayerData pData;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            pData = GameObject.FindWithTag("Player").GetComponent<WorkingPlayerData>();
        }
        SceneNumber = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        SceneNumber = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.E)) 
            {
                pData.CurrentBench = benchNumber;
                pData.CurrentScene = SceneNumber;
                pData.savePlayer();
            }
        }
    }
}
