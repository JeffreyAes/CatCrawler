using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    private int rand;
    public bool spawned = false;
    // 1 ==> need bottom door.
    // 2 ==> neet top door.
    // 3 ==> need left door.
    // 4 ==> right door

    private RoomTemplates templates;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (spawned == false)
        {

              switch(openingDirection)
        {
            case 1:
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], gameObject.transform.position, new Quaternion());
                break;
            case 2:
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], gameObject.transform.position, new Quaternion());
                break;
            case 3:
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], gameObject.transform.position, new Quaternion());
                break;
            case 4:
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], gameObject.transform.position, new Quaternion());
                break;
        }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("spawner"))
        {
            Destroy(gameObject);
        }
    }
}
