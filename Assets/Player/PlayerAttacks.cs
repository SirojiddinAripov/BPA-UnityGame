using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//manages attacks
public class PlayerAttacks : MonoBehaviour
{

    //projectile vars
    public float speed = 20f;
    public Rigidbody2D projectile;
    public GameObject projectilePrefab;


    //dash Vars

    //sword Vars

    private void Update() { //get inputs
        if(Input.GetButtonDown("Mouse2")){
            Debug.Log("Fire Projectile");
        }

        if(Input.GetButtonDown("Mouse1")){
            Debug.Log("Sword Attack")
        }

        if(Input.GetKeyDown("control") && Input.GetButtonDown("Mouse1"){
            Debug.Log("Dash Attack");
        }       
    }

    private void FixedUpdate() {

    }
}