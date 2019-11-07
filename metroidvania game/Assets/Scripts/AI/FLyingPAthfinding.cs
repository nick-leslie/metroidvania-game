using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLyingPAthfinding : MonoBehaviour
{
    private AIBrain brain;
    [SerializeField]
    private float disAway;
    private AiCombat combat;
    // Start is called before the first frame update
    void Start()
    {
        brain = gameObject.GetComponent<AIBrain>();
        combat = transform.GetComponentInChildren<AiCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (brain.Player != null)
        {
            var dir = brain.Player.transform.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            if (Vector2.Distance(brain.Player.transform.position, transform.position) < disAway)
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, brain.Player.transform.position, brain.Speed * Time.deltaTime);
            }
            if (Vector2.Distance(brain.Player.transform.position, transform.position) < brain.attackrad * 2) 
            {
                combat.attack();
            }
        }
    }
}
