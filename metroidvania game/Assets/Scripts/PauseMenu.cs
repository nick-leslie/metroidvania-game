using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    PlayerControls control;
    public GameObject PuaseMeuuUI;

    private void Awake()
    {
        control = new PlayerControls();
        control.controls.Pause.performed += Pause_Performed;;

    }

    void Pause_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void Pause()
    {
        PuaseMeuuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void Resume()
    {
        PuaseMeuuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
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
