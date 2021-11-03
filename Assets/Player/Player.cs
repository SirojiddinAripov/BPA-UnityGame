using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player Class
//Used by the player object in all scenes
//Handles movement
//Handles health
//Triggers events

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public Animator animator;
    public float Health;

    private void Start() {
        Health = 100f;
    }
    private void Update()  //updates with local framerate
    {
        GetInputs();
    }

    private void FixedUpdate()  //updates on set delay (set in editor) 
    {
        Move();
    }

    private void GetInputs() //manage inputs
    {   
        //collect all inputs
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        //set move vector
        moveDirection = new Vector2(moveX, moveY).normalized;
        
        //player movement animations
        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }

    private void Move() //manage movement
    {
        //changes position of the attached rigidbody
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }


    public void takeDamage(float damagePercent)
    {
        Health -= (Health * damagePercent); //takes away a percentage of the health
        if(Health < 1)
        {
            Debug.Log("Player is dead");
        }
    }

    public void heal(float healPercent)
    {
        Health += (Health * healPercent); //heals a percentage of the health
        if(Health >= 100)
        {
            Health = 100;
        }
    }
}
