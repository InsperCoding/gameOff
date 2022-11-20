using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2StateManager : MonoBehaviour
{
    Boss2BaseState currentState;
    //public BossHorizontalAttackState HorizontalAttackState = new BossHorizontalAttackState();
    public Boss2FireAttackState FireAttackState = new Boss2FireAttackState();
    public Boss2MovementState MovingState = new Boss2MovementState();
    
    public Rigidbody2D rb;
    public Transform player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = MovingState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(Boss2BaseState state){
        currentState = state;
        currentState.EnterState(this);
    }
}
