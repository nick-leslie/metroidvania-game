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
    private HealthMainiger hp;
    [SerializeField]
    private float shrinkSpeedMod;
    PlayerControls control;
    private bool PlayerState=true;
    private bool healPressed = false;

    private void Awake()
    {
        control = new PlayerControls();
        control.controls.heal.performed += Heal_Performed;;

    }

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
        hp = player.GetComponent<HealthMainiger>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Heal_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (PauseMenu.gameIsPaused == false)
        {
            if (shrinkingcircalRectTransform.sizeDelta.x <= insidecircalRectTransform.sizeDelta.x && shrinkingcircalRectTransform.sizeDelta.y <= insidecircalRectTransform.sizeDelta.y)
            {
                hp.Health += 1;
                if (hp.Health == hp.maxHeath)
                {
                    healingState(healing);
                }
                //alows to heal up to max health
                else
                {
                    shrinkingcircalRectTransform.sizeDelta = gameObject.GetComponent<circalShrinking>().startsize;
                    shrinkingcircal.GetComponent<circalShrinking>().shrickSpeed += shrinkSpeedMod;
                }
            }
            else
            {
                //otherwhise activates/deactivates healing 
                if (healing == false)
                {
                    healingState(healing);
                }
                else
                {
                    healingState(healing);
                }
            }
        }
    }

    //changes the state of healing to doinng it or not
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
            shrinkingcircal.GetComponent<circalShrinking>().shrickSpeed = shrinkingcircal.GetComponent<circalShrinking>().DefaltSpeed; ;
            healing = false;
        }
        else
        {
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            insidecercal.GetComponent<Image>().enabled = true;
            shrinkingcircal.GetComponent<Image>().enabled = true;
            shrinkingcircal.GetComponent<circalShrinking>().enabled = true;
            player.GetComponent<Movement>().enabled = false;
            player.GetComponent<Jump>().enabled = false;
            healing = true;
        }
    }
    private void OnEnable()
    {
        control.Enable();
    }
    private void OnDisable()
    {
        control.Disable();
    }
}

