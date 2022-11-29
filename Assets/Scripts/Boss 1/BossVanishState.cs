using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVanishState : BossBaseState
{
    float timeToVanish = 1f;
    float timeVanished = 0.5f;
    float timeMaterializing = 1f;
    float timer = 0;
    SpriteRenderer Sprite;
    BoxCollider2D BossHitbox;
    Animator animator;


    public override void EnterState(BossStateManager Boss)
    {
        animator = Boss.GetComponent<Animator>();
        Sprite = Boss.GetComponent<SpriteRenderer>();
        BossHitbox = Boss.GetComponent<BoxCollider2D>();
        Boss.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        timer = 0;
    }

    // A ideia aqui é fazer o boss desaparecer e reaparecer.
    public override void UpdateState(BossStateManager Boss)
    {
        timer += Time.deltaTime;
        if (timer < timeToVanish)
        {
            StartVanish();
        }
        else if (timer < timeToVanish + timeVanished)
        {
            Vanish(Boss);
        }
        else if (timer < timeToVanish + timeVanished + timeMaterializing)
        {
            Appear();
        }
        else if (timer < timeToVanish + timeVanished + timeMaterializing + 0.2)
        {
            animator.SetBool("isAppearing", false);
            animator.SetBool("isAttacking", true);
        }
        else
        {
            Boss.SwitchState(Boss.MovingState);
        }
    }
    void StartVanish()
    {
        animator.SetBool("isVanishing", true);
    }
    void Vanish(BossStateManager Boss)
    {
        Boss.transform.position = new Vector2(Boss.player.position.x, Boss.player.position.y + 1);
        animator.SetBool("isVanishing", false);
        BossHitbox.enabled = false;
        Sprite.enabled = false;
    }
    void Appear()
    {
        animator.SetBool("isAppearing", true);
        BossHitbox.enabled = true;
        Sprite.enabled = true;
    }
}
