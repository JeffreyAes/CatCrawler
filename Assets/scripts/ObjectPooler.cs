using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler current;
    public GameObject pooledObject;
    public int pooledAmount;
    public bool willGrow;

    private List<GameObject> pooledObjects;

    public float attackTimer = 0.1f;
    private float currentAttackTimer = 0.2f;
    private bool canAttack;


    void Awake()
    {
        current = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > currentAttackTimer)
        {
            canAttack = true;
        }
    }



    public GameObject GetPooledObject()
    {


        for (int i = 0; i < pooledObjects.Count; i++)
        {

            if (!pooledObjects[i].activeInHierarchy)
            {
                if (canAttack)
                {
                    canAttack = false;
                    attackTimer = 0f;
                    return pooledObjects[i];
                }
                return null;
            }
                if (willGrow)
                {
                    if (canAttack)
                    {
                        canAttack = false;
                        attackTimer = 0f;
                        GameObject obj = Instantiate(pooledObject);
                        pooledObjects.Add(obj);
                        return obj;
                    }
                    return null;
                }
            }
            return null;

        }
    }
