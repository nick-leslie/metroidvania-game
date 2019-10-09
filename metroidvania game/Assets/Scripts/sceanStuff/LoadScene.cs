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
    private void Awake()
    {
        Maniger = GameObject.FindWithTag("SceneManiger").GetComponent<SceneManiger>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Maniger.UnloadScene = currentScene;
            Maniger.LoadScene = scean;
        }
    }
}
