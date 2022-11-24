using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVerticalHitboxLogic : MonoBehaviour
{
    public GameObject player;
    public int attackDamage;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.name == "PlayerPUp"){
            Debug.Log("Acertou o player!");
            //pseudocodigo => player.dealDamage(attack damage);
        }
    }
}
