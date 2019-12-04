using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    public int Currentbench;
    public int CurrentScene;
    public bool firstrun;
    public PlayerData(WorkingPlayerData pData)
    {
        Currentbench = pData.CurrentBench;
        CurrentScene = pData.CurrentScene;
        firstrun = pData.firstRun;
    }
}
