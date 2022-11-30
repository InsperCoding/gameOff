using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2StateManager : MonoBehaviour
{
    Boss2BaseState currentState;
    float timeSinceLastHit;
    public int currentHealth;

    public int maxHealth;
    public Boss2CloseRangeAttack CloseRangeAttack = new Boss2CloseRangeAttack();
    public Boss2FireAttackState FireAttackState = new Boss2FireAttackState();
    public Boss2MovementState MovingState = new Boss2MovementState();
    
    public Rigidbody2D rb;
    public Transform player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        currentState = MovingState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeSinceLastHit += Time.deltaTime;
        currentState.UpdateState(this);
        if (currentHealth <= 0 ) { Destroy(gameObject); }
    }
    public void SwitchState(Boss2BaseState state){
        currentState = state;
        currentState.EnterState(this);
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
