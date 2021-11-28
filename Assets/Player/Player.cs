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
    public float moveSpeed, moveX, moveY, Health, Mana; //creates some default stats
    public Rigidbody2D rb; //references rigidBody
    private Vector2 moveDirection; //stores the direction for movement
    private Vector3 mousePos; //stores mouse position (X, Y, Z)
    public Animator anim; //references player animator
    public Camera cam; //references camera in scene
    public PlayerStats stats; //references the storage object for player stats
    public GameObject fireball;

    private void Start() { //loads saved data or default player stats
        transform.position = stats.playerCoords;
        Health = stats.playerHealth;
        Mana = stats.playerMana;
    }

    private void Update() //update inputs and reset lockstate every frame
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

    public void GetHurt(float damage){ //takes damage
        Health -= damage;
        Debug.Log("Player Health: " + Health);
    }

    private void Shoot(){ //controls shooting
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("fire");
            Debug.DrawRay(transform.position, mousePos, Color.cyan, 10f);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos, Mathf.Infinity, 9);
            if (hit){
                Debug.Log("Hit");
            }
        }
    }   
}