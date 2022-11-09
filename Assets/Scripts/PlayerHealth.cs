using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Health
    public int currentHealth;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private Animator animator;


    //Knockback
    private Rigidbody2D rb;
    private float strength = 10f;
    private float delay = .2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        for(int i=0; i <hearts.Length; i++)
        {
            if (i < currentHealth){
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

            // Para aumentar a quantidade de coracoes do player
            if (i < numOfHearts){
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }

    private IEnumerator Reset(){
        GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(delay);
        GetComponent<PlayerMovement>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            animator.SetTrigger("Hurt");
            currentHealth--;
            if(currentHealth <= 0){
                GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
            }
            KnockBack(other.gameObject.transform);
        }
    }

    void KnockBack(Transform sender){
        StopAllCoroutines();
        StartCoroutine(Reset());
        Vector2 difference = transform.position - sender.position;
        rb.AddForce(difference * strength, ForceMode2D.Impulse);
    }
}
