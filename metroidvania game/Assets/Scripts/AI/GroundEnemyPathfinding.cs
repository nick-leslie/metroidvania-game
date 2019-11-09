using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyPathfinding : MonoBehaviour
{

    private GameObject pathfinder;
    [SerializeField]
    private AIBrain brain;
    [SerializeField]
    private float moveDire=1;
    private AiCombat combat;
    [SerializeField]
    RaycastHit2D down;
    [SerializeField]
    RaycastHit2D leftRigt;
    // Start is called before the first frame update
    void Start()
    {
        pathfinder = gameObject.transform.GetChild(0).gameObject;
        brain = gameObject.GetComponent<AIBrain>();
        combat = transform.GetComponentInChildren<AiCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        down = Physics2D.Raycast(pathfinder.transform.position, -Vector2.up, brain.attackrad);
        leftRigt = Physics2D.Raycast(pathfinder.transform.position, moveDire * Vector2.right, brain.attackrad);
        if (down.collider != null && leftRigt.collider == null)
        {
            transform.Translate(brain.Speed * Time.deltaTime, 0, 0);
        }
        else
        {
            if (leftRigt.collider != null)
            {
                if (leftRigt.collider.CompareTag("Player"))
                {
                    combat.attack();
                }
                else
                {
                    Flip();
                }
            }
            else
            {
                Flip();
            }
        }
        Debug.DrawRay(pathfinder.transform.position, -Vector2.up, color: Color.blue, brain.attackrad);
        Debug.DrawRay(pathfinder.transform.position, moveDire * Vector2.right, color: Color.blue, brain.attackrad);
    }
    void Flip()
    {
        moveDire = moveDire * -1;
        if (transform.rotation.y == 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
