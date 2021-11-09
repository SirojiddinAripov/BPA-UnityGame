using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour //controls basic enemy movement and attacks
{


    public Transform target;
    [SerializeField] private float speed, health, range;
    private readonly float maxHealth = 100f;
    private void Awake() {
        target = FindObjectOfType<Player>().transform;
        health = maxHealth;
    }

    private void FixedUpdate() {
        if (Vector3.Distance(transform.position, target.position) <= range &&Vector3.Distance(transform.position, target.position) >= 1f){
            followPlayer();
        }
    }

    public void followPlayer(){
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public float getHealth(){
        return health;
    }

    public void takeDamage(float damage){
        health -= damage;
        Debug.Log(health);
    }
}