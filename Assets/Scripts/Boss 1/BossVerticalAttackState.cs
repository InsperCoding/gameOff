using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVerticalAttackState : BossBaseState
{
    float timeToStartAttack = 0.5f;
    float timeOnAttack = 0.5f;
    float recoveryTime = 0.1f;
    float timer = 0;
    GameObject attack;
    BoxCollider2D attackHitbox;
    Animator animator;

    public override void EnterState(BossStateManager boss){
        Debug.Log("Hello from the boss vertical attack state");
        attack = boss.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        attackHitbox = attack.GetComponent<BoxCollider2D>();
        animator = boss.GetComponent<Animator>();
        //boss.currentHealth++;
        timer = 0;

    }

    public override void UpdateState(BossStateManager boss){
        timer += Time.deltaTime;

        if (timer < timeToStartAttack){
            animator.SetBool("isAttacking", true);
        }
        //Active frames
        else if (timer > timeToStartAttack && timer < timeOnAttack + timeToStartAttack){
            activateAttack();
        }
        //Recovery frames
        else if (timer < timeToStartAttack + timeOnAttack + recoveryTime){
            attackHitbox.enabled = false;
            attack.GetComponent<SpriteRenderer>().enabled = false;
        }
        //Fim do estado
        else {
            animator.SetBool("isAttacking", false);
            boss.SwitchState(boss.MovingState);
        }
    }

    void activateAttack(){
        attack.GetComponent<SpriteRenderer>().enabled = true;
        attackHitbox.enabled = true;
    }
}
