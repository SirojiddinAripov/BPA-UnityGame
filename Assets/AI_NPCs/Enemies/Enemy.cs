using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour { //creates enemy framework
    private float health = 100f;
    public float moveSpeed = 4.5f;
    public float baseDamage = 0;
    public Transform target;
    public float chaseRadius = 4f;
    public float attackRadius=1.5f;
    public Player player;
    
    public void Start(){
        
    }

    private void FixedUpdate(){
        Move();
    }

    private void Move(){
        if (Vector3.Distance(transform.position, target.position) <= chaseRadius && Vector3.Distance(transform.position, target.position) >= attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}