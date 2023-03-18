using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletSpeed;



    void OnEnable()
    {
        if(rb != null)
        {
            rb.velocity =  rb.transform.up * bulletSpeed ;
        }
        Invoke("Disable", 2f);
    }

    void Disable()
    {
        gameObject.SetActive(false);

    }

    private void OnDisable()
    {
        CancelInvoke();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "wall":
                Disable();
                break;
            case "enemy":
                Disable();
                other.gameObject.GetComponent<EnemyScript>().TakeDamage();
                // Handle Enemy Collision
                break;
        }
    }

}


