using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
         switch (other.gameObject.tag)
        {
            case "player":
                break;
            case "enemy":
                break;
            case "spawner":
                Destroy(other.gameObject);
                break;
            case "wall":
                Destroy(other.gameObject);
                break;
        }
    }
}
