using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera sceneCamera;
    public float moveSpeed;
    
    // private float minSpeed = 1f;
    public Rigidbody2D rb;
    public Weapon weapon;
    private Vector2 moveDirection;
    private Vector2 mousePosition;

    // Update is called once per frame
    // use for things that need to happen instantly, regardless of other things happening in game.
    void Update()
    {
        ProcessInputs();
    }

    // FixedUpdate is called every 0.2 seconds
    // use for things that need to occur in a controlled amount of time (like physics)
    void FixedUpdate()
    {
        Move();

    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButton(0))
        {
            weapon.Fire();
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

       

        // rotate player to follow the mouse
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}
