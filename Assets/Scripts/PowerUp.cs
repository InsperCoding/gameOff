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


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (coolDown)
        {
            if (keys.Contains(Input.inputString))
            {
                if (keys.Contains(Input.inputString))
                {
                    print("Power Up Activated");
                    ActivatePowerUp();
                    coolDown = false;
                    StartCoroutine("PowerUpCoolDown");
                }
            }
        }


    }


    void ActivatePowerUp()
    {
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
