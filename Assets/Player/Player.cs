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
    public float moveSpeed, moveX, moveY, Health, Mana;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector3 mousePos;
    public Animator anim;
    public Camera cam;
    public PlayerStats stats;

    private void Start() {
        transform.position = stats.playerCoords;
        Health = stats.playerHealth;
        Mana = stats.playerMana;
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        GetInputs();
    }

    private void FixedUpdate() //move and attack on fixed time (50 updates per second)
    {
        Move();      
        Shoot();  
    }

    private void GetInputs() //manage move inputs and positons
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos -= transform.position;
    }

    private void Move() //manage movement and animations
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        
        if(rb.velocity.x != 0 || rb.velocity.y != 0){
            anim.SetFloat("X", moveX);
            anim.SetFloat("Y", moveY);
            anim.SetBool("IsMoving", true);
        }
        else
        {
            rb.velocity = Vector3.zero;
            anim.SetBool("IsMoving", false);
        }
    }

    public void GetHurt(float damage){
        Health -= damage;
        Debug.Log("Player Health: " + Health);
    }

    private void Shoot(){
        if (Input.GetMouseButtonDown(0)){
            Debug.DrawRay(transform.position, mousePos, Color.blue, 10f);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos, Mathf.Infinity, LayerMask.NameToLayer("Enemy"));
            if (hit){
                Debug.Log("Hit: " + hit.collider.gameObject);
            }
        }
    }   
}