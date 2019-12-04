using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CounddownTImer : MonoBehaviour
{
    public int minits;
    public int seconds;
    public TextMeshProUGUI minutesUI;
    public TextMeshProUGUI secondsUI;
    public void startTimer()
    {
        StartCoroutine(demoTimer());
    }
    public IEnumerator demoTimer()
    {
        while (minits > 0)
        {
            yield return new WaitForSeconds(1);
            if(seconds>0)
            {
                seconds -= 1;
            }
            else
            {
                minits -= 1;
                seconds = 60;
            }
            minutesUI.text = minits.ToString();
            secondsUI.text = seconds.ToString();
        }

    }
}
