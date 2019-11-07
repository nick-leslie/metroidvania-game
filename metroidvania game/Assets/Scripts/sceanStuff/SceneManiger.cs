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
    private HealthMainiger hp;
    private WorkingPlayerData pData;
    private GameObject loadingScreen;
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
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player");
        loadingScreen = GameObject.FindWithTag("loadingScreen");
        pData = player.GetComponent<WorkingPlayerData>();
        hp = player.GetComponent<HealthMainiger>();
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
                SceneManager.LoadSceneAsync(StartloadScean, LoadSceneMode.Additive);
                StartCoroutine(setActiveScene(loadSceenNum));
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            else
            {
                SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
                StartCoroutine(setActiveScene(1));
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            GameObject.FindWithTag("StartMenue").SetActive(false);
            gamestart = true;
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(DoWhenSceneLoaded());
    }
    IEnumerator DoWhenSceneLoaded()
    {
        int rightBench=0;
        yield return new WaitForSeconds(0.5f);
        GameObject[] benches = GameObject.FindGameObjectsWithTag("Bench");
        for (int i = 0; i < benches.Length; i++)
        {
            if (benches[i].GetComponent<BenchInteract>().benchNumber == pData.CurrentBench)
            {
                rightBench = i;
                player.transform.position = benches[i].transform.position;
                Debug.Log(loadSceenNum);
                benches[i].GetComponent<BenchInteract>().SceneNumber = loadSceenNum;
            }
        }
       loadingScreen.SetActive(false);
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
        yield return new WaitForSeconds(1);
        //if(SceneManager.GetAllScenes)
        
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
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
