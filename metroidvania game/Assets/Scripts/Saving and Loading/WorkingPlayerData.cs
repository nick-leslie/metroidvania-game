using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WorkingPlayerData : MonoBehaviour
{
    [SerializeField]
    private int _currentBench;
    [SerializeField]
    private int MaxBenchNum;
    [SerializeField]
    private int _currentScene;
    public int CurrentBench
    {
        get { return _currentBench; }
        set
        {
            if(value <= MaxBenchNum && value>0)
            {
                _currentBench = value;
            }
        }
    }
    public int CurrentScene
    {
        get { return _currentScene; }
        set
        {
            if (value <= SceneManager.sceneCountInBuildSettings)
            {
                _currentScene = value;
            }
        }
    }
    private void Start()
    {

    }
    public void savePlayer()
    {
        Debug.Log("saving");
        SavingScript.savePlayer(this);
    }
    public void loadPlayer()
    {
        PlayerData data = SavingScript.loadPlayer();
        _currentBench = data.Currentbench;
        //_currentScene = data.CurrentScene;
        _currentScene = 3;

    }
}
