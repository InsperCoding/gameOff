using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PowerUp : MonoBehaviour
{

    private bool coolDown = true;
    private CircleCollider2D cc;
    private float starterRadious = 0.5f;
    private string[] keys = { "1", "2", "3", "4" };  // 1 = Air, 2 = Fire, 3 = Water, 4 = Earth
    private string key1, key2;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        print(Input.inputString);

        if (coolDown)
        {
            key1 = Input.inputString;
            if (keys.Contains(Input.inputString))
            {
                key2 = Input.inputString;
                if (keys.Contains(Input.inputString))
                {
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

        print(key1 + " " + key2);

        if (key1 == "1")
        {
            if (key2 == "2")
            {
                print("Air + Fire");
            }
            else if (key2 == "3")
            {
                print("Air + Water");
            }
            else if (key2 == "4")
            {
                print("Air + Earth");
            }
        }
        else if (key1 == "2")
        {
            if (key2 == "1")
            {
                print("Fire + Air");
            }
            else if (key2 == "3")
            {
                print("Fire + Water");
            }
            else if (key2 == "4")
            {
                print("Fire + Earth");
            }
        }
        else if (key1 == "3")
        {
            if (key2 == "1")
            {
                print("Water + Air");
            }
            else if (key2 == "2")
            {
                print("Water + Fire");
            }
            else if (key2 == "4")
            {
                print("Water + Earth");
            }
        }
        else if (key1 == "4")
        {
            if (key2 == "1")
            {
                print("Earth + Air");
            }
            else if (key2 == "2")
            {
                print("Earth + Fire");
            }
            else if (key2 == "3")
            {
                print("Earth + Water");
            }
        }

        print("Power Up Activated");
        InvokeRepeating("Grow", 0.1f, 0.1f);
        // cc.radius = radious;
    }
    IEnumerator PowerUpCoolDown()
    {
        yield return new WaitForSeconds(5);
        print("Power Up Ready");
        coolDown = true;
    }
    void Grow()
    {

        if (cc.radius < 1.5f)
        {
            cc.radius += 0.1f;
        }
        else
        {
            cc.radius = starterRadious;
            CancelInvoke("Grow");
        }
    }
}
