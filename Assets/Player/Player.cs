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
    public float moveSpeed, moveX, moveY, Health;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 mousePos;
    public Animator anim;
    public Camera cam;
    private bool walk;

    private void Update()
    {
        GetInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInputs() //manage inputs
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Move() //manage movement and animations
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        
        if(moveX != 0 || moveY != 0){
            anim.SetFloat("X", moveX);
            anim.SetFloat("Y", moveY);
            if (!walk){
                walk = true;
            }
            anim.SetBool("IsMoving", walk);
        }

        else
        {
            if(walk){
                walk = false;
                rb.velocity = Vector3.zero;
            }

            anim.SetBool("IsMoving", walk);
        }
    }
}
