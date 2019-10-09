using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMainiger : MonoBehaviour
{ 
    private int _Health;
    [SerializeField]
    private int MaxHealth;
    [SerializeField]
    private float maxPosible;
    private void Start()
    {
        _Health = MaxHealth;
    }
    public int Health
    {
        get { return _Health; }
        set
        {
            if (value <= MaxHealth) 
            {
                _Health = value;
            }

        }
    }
    public int maxHeath
    {
        get { return maxHeath; }
    }
    public int MaxPossible 
    { 
        get { return maxHeath; }
        set
        {
            if(value<=maxPosible) 
            {
                MaxHealth = value;
            }
        }
    }
}
