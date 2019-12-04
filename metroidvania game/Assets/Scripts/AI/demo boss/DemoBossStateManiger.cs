using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DemoBossStateManiger : MonoBehaviour
{
    //state managment--------------------------------
    enum states{lazers,homingBalls,weakState,idle};
    private states currentState = states.lazers;
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
        for (int j = 0; j < spawnPositions.Length; j++)
        {
            Vector3 dire = spawnPositions[j].transform.position - transform.position;
            spawnPositions[j].transform.GetChild(0).transform.localPosition = dire;
        }
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            Vector3 dire = spawnPositions[i].transform.position - transform.position;
            lazers[i] = Physics2D.Raycast(spawnPositions[i].transform.position, dire, LazerDistence,lazerThingsToHit);
            Debug.DrawRay(spawnPositions[i].transform.position,dire * LazerDistence, Color.blue);
           // spawnPositions[i].GetComponent<LineRenderer>().positionCount = 2;
            //spawnPositions[i].GetComponent<LineRenderer>().SetPosition(0,transform.position);
            //spawnPositions[i].GetComponent<LineRenderer>().SetPosition(1, lazers[i].point);

        }
    }
}
