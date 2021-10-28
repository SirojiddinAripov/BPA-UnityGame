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
    private Vector2 mousePos;
    public Animator animator;
    private float maxHealth = 100f;
    public float Health;
    public Camera cam;

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
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Move() //manage movement
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 lookDir = mousePos - rb.position;
        float zRotation = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = zRotation;
    }
}
