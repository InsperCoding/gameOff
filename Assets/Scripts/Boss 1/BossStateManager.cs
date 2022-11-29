using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{
    BossBaseState currentState;
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
        rb = GetComponent<Rigidbody2D>();
        currentState = MovingState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(BossBaseState state){
        currentState = state;
        state.EnterState(this);

    }
}
