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
    private WorkingPlayerData pData;
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
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        pData = player.GetComponent<WorkingPlayerData>();
    }
   private void loadScean()
    {
        SceneManager.LoadScene(loadSceenNum, LoadSceneMode.Additive);
        StartCoroutine(setActiveScene(loadSceenNum));
        player.transform.position = Vector3.zero;
        StartCoroutine(unload(unloadScean));
    }
    public void StartGame()
    {
        pData.loadPlayer();
        StartloadScean = pData.CurrentScene;
        if (!gamestart)
        {
            if (StartloadScean != 0)
            {
                SceneManager.LoadScene(StartloadScean, LoadSceneMode.Additive);
                StartCoroutine(setActiveScene(loadSceenNum));
            }
            else
            {
                SceneManager.LoadScene(1, LoadSceneMode.Additive);
                StartCoroutine(setActiveScene(1));
            }
            GameObject.FindWithTag("StartMenue").SetActive(false);
            player.SetActive(true);
            player.transform.position = Vector3.zero;
            gamestart = true;
        }
    }
        IEnumerator unload(int sceeen)
        {
            yield return null;
            SceneManager.UnloadScene(sceeen);
        }
        IEnumerator setActiveScene(int scene)
        {
            yield return new WaitForSeconds(0.2f);
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(scene));
        }
}
