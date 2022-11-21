using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2MovementState : Boss2BaseState
{

    float StepTime = 0.8f;
    float RecoveryTime = 0.5f;
    float Timer = 0f;

    //public System.Random Rand { get => Rand; set => Rand = value; }

    public override void EnterState(Boss2StateManager boss)
    {
        Debug.Log("Hello from movement state");
        //Rand = new System.Random();
        Timer = 0f;
    }
    public override void UpdateState(Boss2StateManager Boss)
    {
        Timer += Time.deltaTime;

        Vector2 distance = Boss.player.position - Boss.gameObject.transform.position;
        Vector2 direction = new Vector2(distance.x, distance.y);
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        if (Timer < StepTime)
        {
            Boss.rb.velocity = direction*Boss.speed;
            Boss.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        else if (Timer < StepTime + RecoveryTime)
        {
            Boss.rb.velocity = new Vector2(0,0);
        }
        else if (distance.magnitude > 4)
        {
            Boss.SwitchState(Boss.FireAttackState);
        }
        else if (distance.magnitude < 2)
        {
            Boss.SwitchState(Boss.CloseRangeAttack);
        }

        else
        {
            Debug.Log("NN CRASHA PFFV");
            Timer = 0;
        }
    }
}
