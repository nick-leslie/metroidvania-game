using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class heal : MonoBehaviour
{
    [SerializeField]
    private GameObject insidecercal;
    private GameObject shrinkingcircal;
    private RectTransform insidecircalRectTransform;
    private RectTransform shrinkingcircalRectTransform;
    private GameObject player;
    private bool healing = false;
    // Start is called before the first frame update
    void Start()
    {
        shrinkingcircal = gameObject;
        shrinkingcircalRectTransform = gameObject.GetComponent<RectTransform>();
        insidecircalRectTransform = insidecercal.GetComponent<RectTransform>();
        insidecercal.GetComponent<Image>().enabled = false;
        shrinkingcircal.GetComponent<Image>().enabled = false;
        shrinkingcircal.GetComponent<circalShrinking>().enabled = false;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(shrinkingcircalRectTransform.sizeDelta.x<=insidecircalRectTransform.sizeDelta.x && shrinkingcircalRectTransform.sizeDelta.y <= insidecircalRectTransform.sizeDelta.y)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                //todo
                healingState(healing);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F) && healing==false)
            {
                healingState(healing);
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                healingState(healing);
            }
        }
    }
    public void  healingState(bool state)
    {
        if (state == true)
        {
            player.GetComponent<Movement>().enabled = true;
            player.GetComponent<Jump>().enabled = true;
            insidecercal.GetComponent<Image>().enabled = false;
            shrinkingcircal.GetComponent<Image>().enabled = false;
            shrinkingcircal.GetComponent<circalShrinking>().enabled = false;
            shrinkingcircalRectTransform.sizeDelta = gameObject.GetComponent<circalShrinking>().startsize;
            healing = false;
        }
        else
        {
            insidecercal.GetComponent<Image>().enabled = true;
            shrinkingcircal.GetComponent<Image>().enabled = true;
            shrinkingcircal.GetComponent<circalShrinking>().enabled = true;
            player.GetComponent<Movement>().enabled = false;
            player.GetComponent<Jump>().enabled = false;
            healing = true;
        }
    }
}
