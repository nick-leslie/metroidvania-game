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
    [SerializeField]
    private float filltime;
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
            if(hpm.Health > i)
            {
                StartCoroutine(increceAmount(healthsprites[i]));
            }
            else
            {
                StartCoroutine(decreceAmount(healthsprites[i]));
            }
        }
    }
    IEnumerator decreceAmount(Image healthsprite)
    {
        while (healthsprite.fillAmount>0)
        {
            healthsprite.fillAmount -= filltime;
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator increceAmount(Image healthsprite)
    {
        while (healthsprite.fillAmount < 1)
        {
            healthsprite.fillAmount += filltime;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
