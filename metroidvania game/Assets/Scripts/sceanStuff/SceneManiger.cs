using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManiger : MonoBehaviour
{
    private bool gamestart = false;
    [SerializeField]
    private int StartloadScean;
    private int loadSceenNum;
    private int unloadScean;
    private GameObject player;
    public int LoadScene
    {
        get { return loadSceenNum; }
        set
        {
            if (value <= SceneManager.sceneCountInBuildSettings)
            {
                loadSceenNum = value;
                loadScean();
            }
        }
    }
    public int UnloadScene
    {
        set
        {
            if (value <= SceneManager.sceneCountInBuildSettings)
            {
                unloadScean = value;
            }
        }
    }
    private void Awake()
    {
        if (!gamestart)
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            gamestart = true;
        }
        player = GameObject.FindWithTag("Player");
    }
   private void loadScean()
    {
        SceneManager.LoadSceneAsync(loadSceenNum, LoadSceneMode.Additive);
        player.transform.position = Vector3.zero;
        StartCoroutine(unload(unloadScean));
    }
    IEnumerator unload(int sceeen)
    {
        yield return null;
        SceneManager.UnloadScene(sceeen);
    }
}
