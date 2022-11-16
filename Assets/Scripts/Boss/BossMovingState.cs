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

    public override void UpdateState(BossStateManager boss){
        Vector2 distance = boss.player.position - boss.gameObject.transform.position;
        Vector2 direction = new Vector2(distance.x, distance.y);
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        boss.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Math.Sqrt(distance.x*distance.x + distance.y*distance.y) > 2){
            boss.rb.velocity = (direction * boss.speed);
        } else {
            int isHorizontal = rand.Next(0,2);
            if (isHorizontal == 1){
                boss.SwitchState(boss.HorizontalAttackState);
            } else {
                boss.SwitchState(boss.VerticalAttackState);
            }
        }
    }
}
