using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2CloseRangeAttack : Boss2BaseState
{
    float AttackStartup = 0.7f;
    float AttackDuration = 0.8f;
    float AttackRecovery = 0.5f;
    float Timer = 0f;


    public GameObject Attack;
    public BoxCollider2D AttackHitbox;
    Animator animator;


    public override void EnterState(Boss2StateManager Boss)
    {
        Debug.Log("Hello from the second boss fire state");
        animator = Boss.gameObject.GetComponent<Animator>();
        animator.SetBool("IsAttacking",  true);

        Timer = 0f;
        Attack = Boss.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        AttackHitbox = Attack.GetComponent<BoxCollider2D>();
        //AttackHitbox = Boss.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<PolygonCollider2D>();
    }
    public override void UpdateState(Boss2StateManager Boss)
    {
        //Debug.Log("Ataque fogo");
        Timer += Time.deltaTime;
        if (Timer < AttackStartup){
            ;
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