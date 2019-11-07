using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthMainiger : MonoBehaviour
{ 
    private int _Health;
    [SerializeField]
    private int MaxHealth;
    [SerializeField]
    private float maxPosible;
    [SerializeField]
    private int Itime;
    public bool Invincibal;
    private void Start()
    {
        _Health = MaxHealth;
    }
    public int Health
    {
        get { return _Health; }
        set
        {
            if (Invincibal == false)
            {
                if (value <= MaxHealth)
                {
                    if (value < _Health)
                    {
                        _Health = value;
                        StartCoroutine(Iframes());
                    }
                    else
                    {
                        _Health = value;
                    }

                    if (_Health <= 0)
                    {
                        if (gameObject.CompareTag("Player"))
                        {
                            SceneManager.LoadScene(0);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }

    }
    public int maxHeath
    {
        get { return MaxHealth; }
    }
    public int MaxPossible 
    { 
        get { return maxHeath; }
        set
        {
            if(value>maxPosible) 
            {
                MaxHealth = value;
            }
        }
    }
    public IEnumerator Iframes() 
    {
        Invincibal = true;
        StartCoroutine(coolorShift(Itime,0.2f));
        yield return new WaitForSeconds(Itime);
        Invincibal = false;
    }
    public IEnumerator coolorShift(int amount,float flashHold)
    {
        Color curennt = gameObject.GetComponent<SpriteRenderer>().color;
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(flashHold);
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(flashHold);
            gameObject.GetComponent<SpriteRenderer>().color = curennt;
            yield return new WaitForSeconds(flashHold);
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(flashHold);
            gameObject.GetComponent<SpriteRenderer>().color = curennt;
            yield return new WaitForSeconds(flashHold);
        }
    }
}
