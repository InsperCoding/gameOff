using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PowerUp : MonoBehaviour
{

    private bool coolDown = true;
    private CircleCollider2D cc;
    public float starterRadious = 1.5f;
    public float finalRadious = 0.3f;
    private KeyCode[] keys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };  // 1 = Eletrical, 2 = Fire, 3 = Water, 4 = Earth
    private string key1, key2;

    private SpriteRenderer sr;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // print(Input.inputString);

        if (coolDown)
        {
            if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4))
            {
                print(Input.inputString);
                key1 = Input.inputString;
                print("Power Up Activated");
                ActivatePowerUp(key1);
                coolDown = false;
                StartCoroutine("PowerUpCoolDown");
            }
        }
    }


    void ActivatePowerUp(string key1)
    {


        if (key1 == "1")
        {
            if (GlobalMagicSlots.eletricLevel > 0)
            {
                print("Eletrical");
                animator.SetInteger("Pup", 1);
                cc.radius = finalRadious;
            }
        }
        else if (key1 == "2")
        {
            if (GlobalMagicSlots.fireLevel > 0)
            {
                print("Fire");
                animator.SetInteger("Pup", 2);
                cc.radius = finalRadious;
            }
        }
        else if (key1 == "3")
        {
            if (GlobalMagicSlots.waterLevel > 0)
            {
                print("Water");
                animator.SetInteger("Pup", 3);
                cc.radius = finalRadious;
            }
        }
        else if (key1 == "4")
        {
            if (GlobalMagicSlots.earthLevel > 0)
            {
                print("Earth");
                animator.SetInteger("Pup", 4);
                cc.radius = finalRadious;
            }
        }

        if (cc.radius > starterRadious)
        {
            InvokeRepeating("Shrink", 0.1f, 0.1f);
        }
    }
    IEnumerator PowerUpCoolDown()
    {
        yield return new WaitForSeconds(5);
        print("Power Up Ready");
        coolDown = true;
    }
    void Shrink()
    {

        if (cc.radius > starterRadious)
        {
            cc.radius -= 0.1f;
        }
        else
        {
            print("aaaa");
            cc.radius = starterRadious;
            animator.SetInteger("Pup", 0);
            CancelInvoke("Shrink");
        }
    }
}
