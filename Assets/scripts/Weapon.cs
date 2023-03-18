using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireForce;
    



    public void Fire() {
        // GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        // projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        GameObject obj = ObjectPooler.current.GetPooledObject();
        if(obj == null) return;
        obj.transform.position = firePoint.position;
        obj.transform.rotation = firePoint.rotation;
        obj.SetActive(true);
    }
    
}
