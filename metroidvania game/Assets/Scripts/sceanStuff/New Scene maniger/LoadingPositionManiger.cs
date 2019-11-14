using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPositionManiger : MonoBehaviour
{
    private GameObject player;
    private WorkingPlayerData Pdata;
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player");
        Pdata = player.GetComponent<WorkingPlayerData>();
    }
   public IEnumerator positionToBench()
    {
        int rightBench = 0;
        yield return new WaitForSeconds(0.5f);
        GameObject[] benches = GameObject.FindGameObjectsWithTag("Bench");
        for (int i = 0; i < benches.Length; i++)
        {
            if (benches[i].GetComponent<BenchInteract>().benchNumber == Pdata.CurrentBench)
            {
                rightBench = i;
                player.transform.position = benches[i].transform.position;
            }
        }
    }
}
