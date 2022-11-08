using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementEdulo : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;
    public Transform sword;
    public Sprite[] spriteArray;
    
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    private Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Mouse
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        int animationIdx = ChangeSprite(angle);
        int walkIdx = 0;
        bool moving = false;

        
        if (movement.x != 0 || movement.y != 0)
        {
            moving = true;
        } else {
            moving = false;
        }

        if (moving)
        {
            if (animationIdx == 0 || animationIdx == 4) {
                walkIdx = 1;
            } else if (animationIdx == 1 || animationIdx == 2 || animationIdx == 3) {
                walkIdx = 2;
            } else if (animationIdx == 5 || animationIdx == 6 || animationIdx == 7) {
                walkIdx = 3;
            }
        } else {
            walkIdx = 0;
        }

        animator.SetInteger("AnimationIdx", animationIdx);
        animator.SetInteger("WalkIdx", walkIdx);
        animator.SetBool("Moving",moving);
           
    }

    int ChangeSprite(float angle)
    {
        transform.localScale = new Vector3(1,transform.localScale.y,transform.localScale.z);
        sword.localScale = new Vector3(1,sword.localScale.y,sword.localScale.z);

        if (-22.5 < angle && angle < 22.5) { 
            transform.localScale = new Vector3(-1,transform.localScale.y,transform.localScale.z);
            sword.localScale = new Vector3(-1,sword.localScale.y,sword.localScale.z);
            return 0;
            
        } else if (22.5 < angle && angle < 67.5) {
            transform.localScale = new Vector3(-1,transform.localScale.y,transform.localScale.z); 
            sword.localScale = new Vector3(-1,sword.localScale.y,sword.localScale.z);
            return 1;
       
        } else if (67.5 < angle && angle < 112.5) { 
            return 2;

        } else if (112.5 < angle && angle < 157.5) { 
            return 3;
       
        } else if ((157.5 < angle && angle < 180) || (-180 < angle && angle < -157.5)) { 
            return 4;
       
        } else if (-157.5 < angle && angle < -112.5) { 
        	return 5;
      
        } else if (-112.5 < angle && angle < -67.5) { 
            return 6;
            
        } else if (-67.5 < angle && angle < -22.5) { 
            return 7;
        }
        return -1;
    }
}