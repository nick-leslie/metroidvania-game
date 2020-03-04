using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DemoBossStateManiger : MonoBehaviour
{
    //state managment--------------------------------
    enum states{lazers,homingBalls,weakState,singleLazer};
    [SerializeField]
    private states currentState = states.lazers;
    [SerializeField]
    private int MaxStates;
    private bool corouteneManiger=false;
    //-----------------------------------------------
    [SerializeField]
    private GameObject[] spawnPositions;
    //lazer varubles-------------------------
    [Header("laser state varubles")]
    [SerializeField]
    private float rotationRate;
    [SerializeField]
    private float LazerDamage;
    private RaycastHit2D[] lazers;
    [SerializeField]
    private float LazerDistence;
    [SerializeField]
    private LayerMask lazerThingsToHit;
    [SerializeField]
    private int LazerTimeInState;
    private bool rotOverride;
    //----------------------------------------------
    //----------------------------------------------
    // handline homming balls
    [Header("homming ball state varubles")]
    public GameObject balls;
    public int MaxballAmount;
    public int MinBallAmount;
    public int chanceToSpawn;
    public int timeInBallState;
    [SerializeField]
    private int amount;
    void Start()
    {
        int children = transform.childCount;
        spawnPositions = new GameObject[children];
        lazers = new RaycastHit2D[children];
        for (int i = 0; i < children; i++)
        {
            spawnPositions[i] = transform.GetChild(i).gameObject;
        }
    }


    void Update()
    {
        switch(currentState)
        {
            case states.singleLazer:
                HandleSingle();
                break;
            case states.lazers:
                for (int i = 0; i < spawnPositions.Length; i++)
                {
                    spawnPositions[i].GetComponent<LineRenderer>().enabled = true;
                }
                Handlelazers();
                break;
            case states.homingBalls:
                HandleHoming();
                break;
            case states.weakState:
                break;
        }
    }
    private void Handlelazers()
    {
        if (rotOverride == false)
        { 
        transform.Rotate(new Vector3(0, 0, 1) * (rotationRate * Time.deltaTime));
        }
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            Vector3 dire = spawnPositions[i].transform.position - transform.position;
            lazers[i] = Physics2D.Raycast(spawnPositions[i].transform.position, dire,LazerDistence,lazerThingsToHit);
            Debug.DrawLine(spawnPositions[i].transform.position, lazers[i].point, color: Color.red);
            spawnPositions[i].GetComponent<LineRenderer>().positionCount = 2;
            spawnPositions[i].GetComponent<LineRenderer>().SetPosition(0,spawnPositions[i].transform.position);
            spawnPositions[i].GetComponent<LineRenderer>().SetPosition(1, lazers[i].point);
        }
        if (corouteneManiger==false)
        {
            StartCoroutine(SwitchStates(LazerTimeInState));
        }
    }
    private void HandleSingle()
    {

    }
    private void HandleHoming()
    {
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            float chance = Random.Range(1, 100);
            if (chance > chanceToSpawn && amount < MaxballAmount)
            {
                Instantiate(balls, spawnPositions[i].transform.position, transform.rotation);
                amount++;
            }
        }
        if(amount < MinBallAmount)
        {
            for (int i = 0; i < MinBallAmount-amount; i++)
            {
                Instantiate(balls, spawnPositions[i].transform.position, transform.rotation);
                amount++;
            }
        }
        if (corouteneManiger == false)
        {
            StartCoroutine(SwitchStates(timeInBallState));
        }
    }
    private void HandleWeak()
    {

    }
    IEnumerator SwitchStates(int TimeInState)
    {
        int TimeLeft = 0;
        corouteneManiger = true;
        Quaternion myQuat = Quaternion.Euler(transform.localEulerAngles);
        Quaternion targetQuat = new Quaternion(0, 0, 0, 1);
        Debug.Log(TimeLeft);
        while (TimeLeft<=TimeInState)
        {
            yield return new WaitForSeconds(1);
            TimeLeft++;
        }
        Debug.Log("entering rotation phase");
        rotOverride = true;
        while (myQuat!= targetQuat) 
        {
            transform.localRotation = Quaternion.RotateTowards(myQuat, targetQuat, rotationRate * Time.deltaTime);
            yield return new WaitForSeconds(1f);
            myQuat= Quaternion.Euler(transform.localEulerAngles);
        }
        Debug.Log("entering switch statment");
        switch (currentState)
        { 
            case states.singleLazer:
                currentState = states.lazers;
                break;
            case states.lazers:
                for (int i = 0; i < spawnPositions.Length; i++)
                {
                    spawnPositions[i].GetComponent<LineRenderer>().enabled = false;
                }
                currentState=states.homingBalls;
                Debug.Log("entering other state");
                break;
            case states.homingBalls:
                currentState = states.weakState;
                break;
            case states.weakState:
                currentState = states.singleLazer;
                break;
        }
        rotOverride = false;
        corouteneManiger = false;
    }
}
    