using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCombat : MonoBehaviour
{
    private AIBrain brain;
    private bool _canAttack=false;
    [SerializeField]
    private GameObject slash;
    // Start is called before the first frame update
    void Start()
    {
        brain=transform.parent.gameObject.GetComponent<AIBrain>();
    }

    // Update is called once per frame
   public  void attack()
    {
        if (_canAttack==true)
        {
            StartCoroutine(combatWaitTime());
            StartCoroutine(SlashAnimation());
            Collider2D[] playerToDmg = Physics2D.OverlapCircleAll(transform.position, brain.attackrad);
            for (int i = 0; i < playerToDmg.Length; i++)
            {
                if (playerToDmg[i].CompareTag("Player"))
                {
                    playerToDmg[i].GetComponent<HealthMainiger>().Health -= brain.Damage;
                }
            }
        }
        else
        {
            StartCoroutine(combatWaitTime());
        }

    }
    IEnumerator combatWaitTime()
    {
        _canAttack = false;
        yield return new WaitForSeconds(brain.attackWaitTime);
        _canAttack = true;
    }
    IEnumerator SlashAnimation()
    {
        slash.SetActive(true);
        slash.GetComponent<Animator>().SetBool("active", true);
        slash.GetComponent<Animator>().SetBool("active", false);
        yield return new WaitUntil(() => slash.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("wait") == true);
        slash.SetActive(false);
    }
   // IEnumerator buildUP()
    //{

    //}
    private void OnDrawGizmos()
    {

        Gizmos.DrawSphere(transform.position, brain.attackrad);
        Gizmos.color = Color.red;
    }
}
