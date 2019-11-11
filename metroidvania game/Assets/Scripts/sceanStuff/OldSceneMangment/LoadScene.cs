using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private int scean;
    [SerializeField]
    private int currentScene;
    private SceneManiger Maniger;
    PlayerControls control;
    private float interacting;
    [SerializeField]
    private float InteractWaitTime;
    private bool interacted = false;

    private void Awake()
    {
        control = new PlayerControls();
        control.controls.interact.performed += ctx => interacting = ctx.ReadValue<float>();

    }

    private void Start()
    {
        if (GameObject.FindWithTag("SceneManiger") != null)
        {
            Maniger = GameObject.FindWithTag("SceneManiger").GetComponent<SceneManiger>();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if  (interacting > 0 && interacted == false)
        {
            Maniger.UnloadScene = currentScene;
            Maniger.LoadScene = scean;
            StartCoroutine(timeTillInteraction());
            interacted = true;
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
