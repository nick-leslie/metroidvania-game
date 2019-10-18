using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class circalShrinking : MonoBehaviour
{
    private RectTransform circal;
    [SerializeField]
    private float time;
    public Vector2 startsize;
    public float DefaltSpeed { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        circal = gameObject.GetComponent<RectTransform>();
        startsize = circal.sizeDelta;
        DefaltSpeed = time;
    }
    // Update is called once per frame
    void Update()
    {
        circal.sizeDelta = new Vector2(Mathf.Lerp(circal.sizeDelta.x, 0, time * Time.deltaTime), Mathf.Lerp(circal.sizeDelta.y, 0, time * Time.deltaTime));
        if (circal.sizeDelta.x <= 100 && circal.sizeDelta.y <= 100)
        {
            circal.sizeDelta = startsize;
        }
    }
    public float shrickSpeed
    {
        get { return time; }
        set
        {
            time = value;
        }
    }
}
