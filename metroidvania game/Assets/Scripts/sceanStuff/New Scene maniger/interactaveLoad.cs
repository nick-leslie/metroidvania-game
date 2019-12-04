using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactaveLoad : MonoBehaviour
{
    private SceneManigerBace manigerBace;
    [SerializeField]
    private int toBeLoaded;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("SceneManiger") != null)
        {
            manigerBace = GameObject.FindWithTag("SceneManiger").GetComponent<SceneManigerBace>();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        manigerBace.LoadScene(toBeLoaded,true);
        other.transform.position = new Vector3(0, 0, 0);
    }
}
