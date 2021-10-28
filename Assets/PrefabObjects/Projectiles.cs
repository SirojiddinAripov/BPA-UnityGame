using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles projectile behaivior on collision
public class Projectiles : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
