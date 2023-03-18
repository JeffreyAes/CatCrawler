using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public  Transform target;
    public Rigidbody2D rb;
    public float movementSpeed = 5f;
    private int enenmyHealth = 5;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame

    void Update()
    {
          transform.right = (target.position - transform.position) *-1;
        if(enenmyHealth < 1)
        {
             DestroyEnemy();
        }
    }

    public void TakeDamage()
    {
        enenmyHealth--;
    }

void DestroyEnemy()
{
    Destroy(gameObject);
}

}
