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
    private Vector3 mousePos;
    public Animator anim;
    public Camera cam;
    private bool walk;
    public PlayerCoords startPos;

    private void Awake() {
        Cursor.lockState = CursorLockMode.Confined;
        transform.position = startPos.initValue;
    }

    private void Update()
    {
        GetInputs();
    }

    private void FixedUpdate() //move and attack on fixed time (50 updates per second)
    {
        Move();
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }
        
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
            if(walk){
                rb.velocity = Vector3.zero;
            }
            anim.SetBool("IsMoving", false);
        }
    }

    private void Shoot(){//manages shooting
        int layerMask = (LayerMask.GetMask("Enemy"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos, Mathf.Infinity, layerMask); //creates ray
        Debug.DrawRay(transform.position, mousePos, Color.blue, 10f);

        if (hit){
            Debug.Log("Raycast: " + hit.collider.gameObject);
            Enemy enemy = (hit.collider.gameObject.GetComponent<Enemy>());
            GameObject other = hit.collider.gameObject;

            if(enemy != null){
                float damage = Random.Range(0.15f, 0.25f);
                damage *= enemy.getMaxHealth();
                enemy.takeDamage(damage);

                if (enemy.getHealth() <= 1f){
                    Destroy(other);
                    Debug.Log("Enemy has died");
                }
            }
        }
    }
}