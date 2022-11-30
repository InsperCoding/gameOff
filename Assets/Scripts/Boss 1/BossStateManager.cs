using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{
    BossBaseState currentState;
    int currentHealth;
    float timeSinceLastHit;

    public int maxHealth;
    public BossHorizontalAttackState HorizontalAttackState = new BossHorizontalAttackState();
    public BossVerticalAttackState VerticalAttackState = new BossVerticalAttackState();
    public BossMovingState MovingState = new BossMovingState();
    public BossVanishState VanishState = new BossVanishState();


    public Rigidbody2D rb;
    public Transform player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastHit = 0;
        rb = GetComponent<Rigidbody2D>();
        currentState = MovingState;

        currentState.EnterState(this);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeSinceLastHit += Time.deltaTime;
        currentState.UpdateState(this);
        if (currentHealth <= 0) { Destroy(gameObject); }
    }
    public void SwitchState(BossBaseState state)
    {
        currentState = state;
        state.EnterState(this);

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Bateu");
        if ((collider.gameObject.tag == "Sword" || collider.gameObject.tag == "PowerUp") && timeSinceLastHit > 1)
        {
            currentHealth -= 1;
            timeSinceLastHit = 0;
        }
    }
}
