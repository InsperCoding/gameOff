using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public Transform player;

    private int currentHealth;
    private Rigidbody2D rb;
    private float strength = 3f;
    private float delay = 0.5f;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private IEnumerator Reset(){
        GetComponent<AIDestinationSetter>().enabled = false;
        GetComponent<AIPath>().enabled = false;
        yield return new WaitForSeconds(delay);
        GetComponent<AIDestinationSetter>().enabled = true;
        GetComponent<AIPath>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Sword"){
            TakeDamage();
        }
    }

    void TakeDamage(){
        currentHealth--;
        animator.SetTrigger("TookDamage");
        if(currentHealth <= 0){
            Destroy(gameObject);
        }
        KnockBack();
    }

    void KnockBack(){
        StopAllCoroutines();
        StartCoroutine(Reset());
        Vector2 difference = transform.position - player.position;
        rb.AddForce(difference * strength, ForceMode2D.Impulse);
    }
}
