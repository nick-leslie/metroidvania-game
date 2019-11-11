using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLyingPAthfinding : MonoBehaviour
{
    private AIBrain brain;
    [SerializeField]
    private float disAway;
    private AiCombat combat;
    private RaycastHit2D sightline;
    private Transform attackpoint;
    // Start is called before the first frame update
    void Start()
    {
        brain = gameObject.GetComponent<AIBrain>();
        combat = transform.GetComponentInChildren<AiCombat>();
        attackpoint = gameObject.transform.GetChild(0).gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (brain.Player != null)
        {
            sightline = Physics2D.Raycast(attackpoint.position, brain.Player.transform.position - transform.position);
            var dir = brain.Player.transform.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            if (Vector2.Distance(brain.Player.transform.position, transform.position) < disAway)
            {
                    if (sightline.collider.CompareTag("Player"))
                    {
                        transform.position = Vector3.MoveTowards(gameObject.transform.position, brain.Player.transform.position, brain.Speed * Time.deltaTime);
                    }
                else
                {
                    return;
                }
            }
            if (Vector2.Distance(brain.Player.transform.position, transform.position) < brain.attackrad * 2)
            {
                combat.attack();
            }
        }
        else
        {
            brain.findP();
        }
    }
}
