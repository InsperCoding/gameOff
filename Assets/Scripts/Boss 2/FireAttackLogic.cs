using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttackLogic : MonoBehaviour
{
    public GameObject player;
    public int attackDamage;

    PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            Debug.Log("Acertou o player!");
            playerHealth.Damage(transform.parent.gameObject.transform.parent.gameObject.transform);
            transform.parent.gameObject.transform.parent.gameObject.GetComponent<BossStateManager>().currentHealth++;
        }
    }
}
