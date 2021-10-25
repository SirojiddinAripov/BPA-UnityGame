using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; //sets move speed (can be changed in )
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public Animator animator;
    [SerializeField] private float maxHealth = 60f;

    private void Start() 
    {
        
    }


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
    }

    private void Move() //manage movement
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Attack() //manage attacks
    {

    }
}
