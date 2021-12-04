using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour //controls basic enemy movement and attacks
{


    public Transform target;
    public Rigidbody2D rb;
    private Vector2 moveDir;
    [SerializeField] private float speed, health, range;
    private readonly float maxHealth = 100f;
    private EnemyStats stats;
    private void Awake() {
        target = FindObjectOfType<Player>().transform;
    }

    private void FixedUpdate() {
        if (Vector3.Distance(transform.position, target.position) <= range &&Vector3.Distance(transform.position, target.position) >= 1f){
            followPlayer();
        }

        float moveX = target.position.x - transform.position.x;
        float moveY = target.position.y - transform.position.y;

        moveDir = new Vector2(moveX, moveY);
    }

    public void followPlayer(){
        rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
    }

    public float getMaxHealth(){
        return maxHealth;
    }
    public float getHealth(){
        return health;
    }

    public void takeDamage(float damage){
        health -= damage;
        Debug.Log(health);
    }
}