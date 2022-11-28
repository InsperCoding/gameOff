using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovingState : BossBaseState
{
    System.Random rand;
    public override void EnterState(BossStateManager boss){
        Debug.Log("Hello from movement state");
        rand = new System.Random();
    }

    public override void UpdateState(BossStateManager Boss){
        Vector2 distance = Boss.player.position - Boss.gameObject.transform.position;
        Vector2 direction = new Vector2(distance.x, distance.y);
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Boss.transform.GetChild(0).gameObject.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (distance.x > 0)
        {
            Boss.GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            Boss.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Math.Sqrt(distance.x*distance.x + distance.y*distance.y) > 2){
            Boss.rb.velocity = (direction * Boss.speed);
        } else {
            int isHorizontal = rand.Next(0,2);
            if (isHorizontal == 1){
                Boss.SwitchState(Boss.HorizontalAttackState);
            } else {
                Boss.SwitchState(Boss.VerticalAttackState);
            }
        }
    }
}
