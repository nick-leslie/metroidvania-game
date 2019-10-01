using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private Image[] healthsprites; 
    private GameObject player;
    private HealthMainiger hpm;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] tempimage = GameObject.FindGameObjectsWithTag("heath points");
        healthsprites = new Image[tempimage.Length];
        for (int i = 0; i < tempimage.Length; i++)
        {
            healthsprites[i] = tempimage[i].GetComponent<Image>();
        }
        player = GameObject.FindWithTag("Player");
        hpm = player.GetComponent<HealthMainiger>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < healthsprites.Length; i++)
        {
            if( hpm.Health > i )
            {
                healthsprites[i].color = Color.white;
            }
            else
            {
                healthsprites[i].color = Color.gray;
            }
        }
    }
}
