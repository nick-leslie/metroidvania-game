using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLyingPAthfinding : MonoBehaviour
{
    private AIBrain brain;
    [SerializeField]
    private float disAway;
    // Start is called before the first frame update
    void Start()
    {
        brain = gameObject.GetComponent<AIBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(brain.Player.transform.position,transform.position) < disAway)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, brain.Player.transform.position, brain.Speed * Time.deltaTime);
        }
    }
}
