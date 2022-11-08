using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform center;
    private Vector3 v;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        v = (transform.position - center.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centerScreenPos = Camera.main.WorldToScreenPoint (transform.position);
        Vector3 dir = Input.mousePosition - centerScreenPos;
        float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis (angle - 90, Vector3.forward);
        transform.position = transform.position + q * v;
        transform.rotation = q;

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
