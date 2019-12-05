using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DemoBossStateManiger : MonoBehaviour
{
    //state managment--------------------------------
    enum states{lazers,homingBalls,weakState,idle};
    private states currentState = states.lazers;
    [SerializeField]
    private int MaxStates;
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
            case states.idle:
                break;
            case states.lazers:
                Handlelazers();
                break;
            case states.homingBalls:
                break;
            case states.weakState:
                break;
        }
    }
    private void Handlelazers() 
    {
        transform.Rotate(new Vector3(0,0,1) * (rotationRate * Time.deltaTime));
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            Vector3 dire = spawnPositions[i].transform.position - transform.position;
            lazers[i] = Physics2D.Raycast(spawnPositions[i].transform.position, dire,LazerDistence,lazerThingsToHit);
            Debug.DrawLine(spawnPositions[i].transform.position, lazers[i].point, color: Color.blue);
            spawnPositions[i].GetComponent<LineRenderer>().positionCount = 2;
            spawnPositions[i].GetComponent<LineRenderer>().SetPosition(0,spawnPositions[i].transform.position);
            spawnPositions[i].GetComponent<LineRenderer>().SetPosition(1, lazers[i].point);
        }
        //StartCoroutine(SwitchStates(LazerTimeInState));
    }
    IEnumerator SwitchStates(int TimeInState)
    {
        int TimeLeft = 0;
        while (TimeLeft<=TimeInState)
        {
            yield return new WaitForSeconds(1);
            TimeLeft++;
        }
        switch (currentState)
        {
            case states.idle:
                currentState = states.lazers;
                break;
            case states.lazers:
               currentState=states.homingBalls;
                break;
            case states.homingBalls:
                currentState = states.weakState;
                break;
            case states.weakState:
                currentState = states.idle;
                break;
        }
    }
}
    