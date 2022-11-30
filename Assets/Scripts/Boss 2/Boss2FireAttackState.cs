using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2FireAttackState : Boss2BaseState
{
    float AttackStartup = 0.7f;
    float AttackDuration = 0.8f;
    float AttackRecovery = 0.1f;
    float Timer = 0f;
    float angle;
    Vector2 direction;
    Animator animator;
    Quaternion rotationQuaternion;


    public GameObject Attack;
    public BoxCollider2D AttackHitbox;
    



    public override void EnterState(Boss2StateManager Boss)
    {
        animator = Boss.gameObject.GetComponent<Animator>();
        animator.SetBool("IsAttacking",  true);
        Debug.Log("Hello from the second boss fire state");
        Timer = 0f;
        Attack = Boss.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        AttackHitbox = Attack.GetComponent<BoxCollider2D>();
        //AttackHitbox = Boss.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<PolygonCollider2D>();
    }
    public override void UpdateState(Boss2StateManager Boss)
    {
        Debug.Log("Ataque fogo");
        Timer += Time.deltaTime;
        if (Timer < AttackStartup){
            direction = (Boss.player.position - Boss.transform.position).normalized;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rotationQuaternion = Quaternion.Euler(0f, 0f, angle);
            Boss.transform.GetChild(0).gameObject.transform.rotation = Quaternion.Slerp(Boss.transform.GetChild(0).gameObject.transform.rotation, rotationQuaternion, 1f*Time.deltaTime);
        }
        else if(Timer < AttackStartup + AttackDuration)
        {
            AttackHitbox.enabled = true;
            Attack.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if(Timer < AttackStartup + AttackDuration + AttackRecovery)
        {
            AttackHitbox.enabled = false;
            Attack.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }
        else {
            Timer = 0;
            Boss.SwitchState(Boss.MovingState);
        }
    }
}
