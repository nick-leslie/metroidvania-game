using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManigerBace : MonoBehaviour
{
    //the whole scene managment will go off of yousing a bace  scene
    private int baceScene = 0;
    private GameObject player;
    private WorkingPlayerData Pdata;
    private LoadingPositionManiger posManager;
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player");
        Pdata = player.GetComponent<WorkingPlayerData>();
        posManager = gameObject.GetComponent<LoadingPositionManiger>();
    }

    //this is the bace load profile
    public void LoadProfile()
    {
        Pdata.loadPlayer();
        if (Pdata.CurrentScene > 0 )
        {
            LoadScene(Pdata.CurrentScene,false);
        }
        else
        {
            LoadScene(1,false);
        }
    }
    //this is used for the games loading levles in run time
   public void LoadScene(int loadSceneNumber, bool unload)
    {
        List<Scene> listOfActive = new List<Scene>();
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            listOfActive.Add(SceneManager.GetSceneAt(i));
        }
        if (unload == true)
        {
            SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByBuildIndex(0));
            for (int i = 0; i < listOfActive.Count; i++)
            {
                if (listOfActive[i].buildIndex != 0)
                {
                    StartCoroutine(unLoadScene(listOfActive[i].buildIndex));
                }
            }
        }
        SceneManager.LoadSceneAsync(loadSceneNumber, LoadSceneMode.Additive);
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByBuildIndex(loadSceneNumber));
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    //this is used or unloading addative scenes
    IEnumerator unLoadScene(int sence)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
        yield return null;
        SceneManager.UnloadScene(sence);

    }
    //lissening for the scene loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
        StartCoroutine(posManager.positionToBench());
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
