using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2FireAttackState : Boss2BaseState
{
    float AttackStartup = 1f;
    float AttackDuration = 3f;
    float AttackRecovery = 1f;
    float Timer = 0f;


    public GameObject Attack;
    public PolygonCollider2D AttackHitbox;


    public override void EnterState(Boss2StateManager Boss)
    {
        Debug.Log("Hello from the second boss fire state");
        Timer = 0f;
        Attack = Boss.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        AttackHitbox = Attack.GetComponent<PolygonCollider2D>();
        //AttackHitbox = Boss.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<PolygonCollider2D>();
    }
    public override void UpdateState(Boss2StateManager Boss)
    {
        Debug.Log("Ataque fogo");
        Timer += Time.deltaTime;
        if (Timer < AttackStartup + AttackDuration)
        {
            AttackHitbox.enabled = true;
        }
        else if(Timer < AttackStartup + AttackDuration + AttackRecovery)
        {
            AttackHitbox.enabled = false;
        }
        else {
            Timer = 0;
            Boss.SwitchState(Boss.MovingState);
        }
    }
}
