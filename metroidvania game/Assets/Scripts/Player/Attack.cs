using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private float radis;
    [SerializeField]
    private LayerMask whattohit;
    [SerializeField]
    private float outdegree;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direPointed = new Vector2(x, y);
         pos = new Vector3((player.transform.position.x) * direPointed.x, (player.transform.position.y) * direPointed.y, 0);
        Physics2D.OverlapCircleAll(pos, radis, whattohit);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos, radis);
    }
}
