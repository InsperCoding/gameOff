using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVerticalAttackState : BossBaseState
{
    float timeOnAttack  = 1.3f;
    float timeToStartAttack = 0.3f;
    float recoveryTime = 1f;
    float timer = 0;
    GameObject attack;
    BoxCollider2D attackHitbox;

    public override void EnterState(BossStateManager boss){
        Debug.Log("Hello from the boss vertical attack state");
        boss.rb.velocity = (new Vector2(0,0));
        attack = boss.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        attackHitbox = attack.GetComponent<BoxCollider2D>();
        
        timer = 0;

        activateAttack();
    }

    public override void UpdateState(BossStateManager boss){
        timer += Time.deltaTime;

        if (timer < timeToStartAttack){
            ;
        }
        //Active frames
        else if (timer > timeToStartAttack && timer < timeOnAttack + timeToStartAttack){
            activateAttack();
        }
        //Recovery frames
        else if (timer < timeToStartAttack + timeOnAttack + recoveryTime){
            attackHitbox.enabled = false;
        }
        //Fim do estado
        else {
            boss.SwitchState(boss.MovingState);
        }
    }

    void activateAttack(){
        attackHitbox.enabled = true;
    }
}
