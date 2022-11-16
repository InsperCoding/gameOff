using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    public float speed;
    public int bossHealth;
    public Transform player;

    private Rigidbody2D rb;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = player.position - transform.position;
        direction.Normalize();
    }

    void Update(){
        direction = player.position - transform.position;
        direction.Normalize();
    }
    void FixedUpdate()
    {
        moveEnemy(direction);
    }
    void moveEnemy(Vector2 direction){
        rb.velocity = (direction*speed);
    }
}
