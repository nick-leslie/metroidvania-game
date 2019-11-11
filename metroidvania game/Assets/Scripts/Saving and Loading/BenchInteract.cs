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
    PlayerControls control;
    private float interacting;
    [SerializeField]
    private float InteractWaitTime;
    private bool interacted=false;
    private void Awake()
    {
        control = new PlayerControls();
        control.controls.interact.performed += ctx => interacting=ctx.ReadValue<float>();
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
            if(interacting>0 && interacted==false) 
            {
                pData.CurrentBench = benchNumber;
                pData.CurrentScene = SceneNumber;
                pData.savePlayer();
                Debug.Log("whow ya");
                StartCoroutine(timeTillInteraction());
                interacted = true;
            }
        }
    }
    IEnumerator timeTillInteraction()
    {
        yield return new WaitForSeconds(InteractWaitTime);
        interacted = false;
    }
    private void OnEnable()
    {
        control.Enable();
    }
    private void OnDisable()
    {
        control.Disable();
    }
}
