using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public float attackRadius;
    public Transform center;

    private Vector2 mousePos;
    private Vector2 centerPos;
    private float mouseDis;

    // Start is called before the first frame update
    void Start()
    {
        //centerPosition = new Vector2(center.position.x, center.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        centerPos = center.position;
        mouseDis = (mousePos - centerPos).sqrMagnitude;
        
        if (mouseDis < attackRadius)
        {
            transform.position = mousePos;

        } else {

            int signal = (mousePos - centerPos).x < 0 ? -1 : 1;

            float tg = (mousePos - centerPos).y / (mousePos - centerPos).x;
            float x = attackRadius / Mathf.Sqrt(1 + tg*tg);
            float y = x*tg;

            transform.position = new Vector2((x*signal + centerPos.x),(y*signal + centerPos.y));
        }
    }

}
