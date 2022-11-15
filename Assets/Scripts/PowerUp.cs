using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PowerUp : MonoBehaviour
{

    private bool coolDown = true;
    private CircleCollider2D cc;
    private float starterRadious = 1.5f;
    private KeyCode[] keys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };  // 1 = Air, 2 = Fire, 3 = Water, 4 = Earth
    private string key1, key2;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // print(Input.inputString);

        if (coolDown)
        {
            if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4))
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    if (Input.GetKey(keys[i]))
                    {
                        key1 = keys[i].ToString();
                    }
                }
                // key1 = (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4)).ToString();
                if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyUp(KeyCode.Alpha4))
                {
                    for (int i = 0; i < keys.Length; i++)
                    {
                        if (Input.GetKeyUp(keys[i]))
                        {
                            key2 = keys[i].ToString();
                        }
                    }
                    print("Power Up Activated");
                    ActivatePowerUp(key1, key2);
                    coolDown = false;
                    StartCoroutine("PowerUpCoolDown");
                }
            }
        }


    }


    void ActivatePowerUp(string key1, string key2)
    {


        if (key1 == "Alpha1")
        {
            if (key2 == "Alpha2")
            {
                print("Air + Fire");
            }
            else if (key2 == "Alpha3")
            {
                print("Air + Water");
            }
            else if (key2 == "Alpha4")
            {
                print("Air + Earth");
            }
        }
        else if (key1 == "Alpha2")
        {
            if (key2 == "Alpha1")
            {
                print("Fire + Air");
            }
            else if (key2 == "Alpha3")
            {
                print("Fire + Water");
            }
            else if (key2 == "Alpha4")
            {
                print("Fire + Earth");
            }
        }
        else if (key1 == "Alpha3")
        {
            if (key2 == "Alpha1")
            {
                print("Water + Air");
            }
            else if (key2 == "Alpha2")
            {
                print("Water + Fire");
            }
            else if (key2 == "Alpha4")
            {
                print("Water + Earth");
            }
        }
        else if (key1 == "Alpha4")
        {
            if (key2 == "Alpha1")
            {
                print("Earth + Air");
            }
            else if (key2 == "Alpha2")
            {
                print("Earth + Fire");
            }
            else if (key2 == "Alpha3")
            {
                print("Earth + Water");
            }
        }
        cc.radius = starterRadious;
        InvokeRepeating("Shrink", 0.1f, 0.1f);
        // cc.radius = radious;
    }
    IEnumerator PowerUpCoolDown()
    {
        yield return new WaitForSeconds(5);
        print("Power Up Ready");
        coolDown = true;
    }
    void Shrink()
    {

        if (cc.radius > 0.3f)
        {
            cc.radius -= 0.1f;
        }
        else
        {
            cc.radius = starterRadious;
            CancelInvoke("Shrink");
        }
    }
}
