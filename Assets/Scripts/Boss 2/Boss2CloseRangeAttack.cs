using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2CloseRangeAttack : Boss2BaseState
{
    float AttackStartup = 0.6f;
    float AttackDuration = 1f;
    float AttackRecovery = 0.5f;
    float Timer = 0f;


    public GameObject Attack;
    public PolygonCollider2D AttackHitbox;


    public override void EnterState(Boss2StateManager Boss)
    {
        Debug.Log("Hello from the second boss fire state");
        Timer = 0f;
        Attack = Boss.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
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