using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBrain : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed;
    private float speed;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private int MaxDamage;
    private int damage;
    private HealthMainiger heath;
    private Color ogcolor;
    public bool tookDmg=false;
    [SerializeField]
    private float _attackRad;
    public float attackWaitTime; 
    public GameObject Player
    {
        get { return player; }
        set
        {
            if(value.CompareTag("Player"))
            {
                player = value;
            }
        }
    }
    public float Speed
    {
        get { return speed; }
        set
        {
            if(value<=maxSpeed)
            {
                speed=value;
            }
            else
            {
                speed = maxSpeed;
            }
        }
    }
    public int Damage
    {
        get { return damage; }
        set
        {
            if(value<=MaxDamage)
            {
                damage = value;
            }
        }
    }
    public float attackrad
    {
        get { return _attackRad; }
        set
        {
            _attackRad = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        findP();
        speed = maxSpeed;
        damage = MaxDamage;
        heath = gameObject.GetComponent<HealthMainiger>();
        ogcolor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    public void takeDamage(int amount)
    {
        if (tookDmg==false)
        {
            heath.Health -= amount;
            StartCoroutine(dammag());
            if (heath.Health <= 0)
            {
                die();
            }
        }
        else
        {
            return;
        }
    }
    public void die() 
    {
        Destroy(gameObject);
    }
   public  void findP()
    {
        player = GameObject.FindWithTag("Player");
    }
    private IEnumerator dammag()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSecondsRealtime(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
