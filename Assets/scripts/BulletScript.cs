using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb;


    void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "wall":
            Destroy(gameObject);
            break;
            case "enemy":
            Destroy(gameObject);
            // other.GameObject.GetComponent<MyEnemyScript>().TakeDamage();
            // Handle Enemy Collision
            Destroy(gameObject);
            break;
        }
    }
}
