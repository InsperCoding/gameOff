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

    public GameObject InventoryPup;
    public InventorySlot[] magicSlots;
    InventoryItem[] itemInSlot = { null, null, null, null };
    InventorySlot[] slot = { null, null, null, null };
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        InventoryPup = GameObject.Find("InventoryPup").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // print(Input.inputString);

        if (coolDown)
        {
            if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4))
            {
                coolDown = false;
                print(Input.inputString);
                key1 = Input.inputString;
                print("Power Up Activated");
                ActivatePowerUp(key1);
                StartCoroutine("PowerUpCoolDown");
            }
        }
    }


    void ActivatePowerUp(string key1)
    {

        for (int i = 0; i < magicSlots.Length; i++)
        {
            print(i);
            magicSlots[i] = InventoryPup.transform.GetChild(i).GetComponent<InventorySlot>();
            slot[i] = magicSlots[i];
            itemInSlot[i] = slot[i].GetComponentInChildren<InventoryItem>();
        }


        if (key1 == "1")
        {
            print(itemInSlot);
            if (itemInSlot[1] != null)
            {
                if (itemInSlot[1].item.name == "Eletrical")
                {
                    print("Eletrical");
                    animator.SetInteger("Pup", 1);
                    cc.radius = finalRadious;
                }
                if (itemInSlot[1].item.name == "Fire")
                {
                    print("Fire");
                    animator.SetInteger("Pup", 2);
                    cc.radius = finalRadious;
                }
                if (itemInSlot[1].item.name == "Water")
                {
                    print("Water");
                    animator.SetInteger("Pup", 3);
                    cc.radius = finalRadious;
                }
                if (itemInSlot[1].item.name == "Earth")
                {
                    print("Earth");
                    animator.SetInteger("Pup", 4);
                    cc.radius = finalRadious;
                }
            }

        }
        else if (key1 == "2")
        {
            if (itemInSlot[2] != null)
            {
                if (itemInSlot[2].item.name == "Eletrical")
                {
                    print("Eletrical");
                    animator.SetInteger("Pup", 1);
                    cc.radius = finalRadious;
                }
                if (itemInSlot[2].item.name == "Fire")
                {
                    print("Fire");
                    animator.SetInteger("Pup", 2);
                    cc.radius = finalRadious;
                }
                if (itemInSlot[2].item.name == "Water")
                {
                    print("Water");
                    animator.SetInteger("Pup", 3);
                    cc.radius = finalRadious;
                }
                if (itemInSlot[2].item.name == "Earth")
                {
                    print("Earth");
                    animator.SetInteger("Pup", 4);
                    cc.radius = finalRadious;
                }
            }
        }
        else if (key1 == "3")
        {
            if (itemInSlot[3] != null)
            {
                if (itemInSlot[3].item.name == "Eletrical")
                {
                    print("Eletrical");
                    animator.SetInteger("Pup", 1);
                    cc.radius = finalRadious;
                }
                if (itemInSlot[3].item.name == "Fire")
                {
                    print("Fire");
                    animator.SetInteger("Pup", 2);
                    cc.radius = finalRadious;
                }
                if (itemInSlot[3].item.name == "Water")
                {
                    print("Water");
                    animator.SetInteger("Pup", 3);
                    cc.radius = finalRadious;
                }
                if (itemInSlot[3].item.name == "Earth")
                {
                    print("Earth");
                    animator.SetInteger("Pup", 4);
                    cc.radius = finalRadious;
                }
            }
        }
        else if (key1 == "4")
        {
            if (itemInSlot[4] != null)
            {
                if (itemInSlot[4].item.name == "Eletrical")
                {
                    print("Eletrical");
                    animator.SetInteger("Pup", 1);
                    cc.radius = finalRadious;
                }
                if (itemInSlot[4].item.name == "Fire")
                {
                    print("Fire");
                    animator.SetInteger("Pup", 2);
                    cc.radius = finalRadious;
                }
                if (itemInSlot[4].item.name == "Water")
                {
                    print("Water");
                    animator.SetInteger("Pup", 3);
                    cc.radius = finalRadious;
                }
                if (itemInSlot[4].item.name == "Earth")
                {
                    print("Earth");
                    animator.SetInteger("Pup", 4);
                    cc.radius = finalRadious;
                }
            }
        }


        if (cc.radius > starterRadious)
        {
            StartCoroutine("PowerUpActivated");
            // InvokeRepeating("Shrink", 0.1f, 0.1f);
        }
    }
    IEnumerator PowerUpCoolDown()
    {
        yield return new WaitForSeconds(5);
        print("Power Up Ready");
        coolDown = true;
    }
    IEnumerator PowerUpActivated()
    {
        yield return new WaitForSeconds(1.5f);
        cc.radius = starterRadious;
        animator.SetInteger("Pup", 0);

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
