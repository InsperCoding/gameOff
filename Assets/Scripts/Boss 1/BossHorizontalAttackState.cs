using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class BossHorizontalAttackState : BossBaseState
{
    float timeToStartAttack  = 0.8f;
    float timeOnAttack = 1f;
    float recoveryTime = 0.5f;
    float timer = 0;
    GameObject attack;
    BoxCollider2D attackHitbox;

    public override void EnterState(BossStateManager boss){
        Debug.Log("Hello from the boss horizontal attack state");
        boss.rb.velocity = (new Vector2(0,0));
        attack = boss.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        attackHitbox = attack.GetComponent<BoxCollider2D>();
        
        timer = 0;
    }

    public override void UpdateState(BossStateManager boss){
        timer += Time.deltaTime;
        //StartUp frames
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
