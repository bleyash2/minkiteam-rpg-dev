using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody rb;
    Vector3 movement;
    void handleMovement()
    {
        movement.x = -Input.GetAxisRaw("Horizontal");
        movement.z = -Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }

    void Update()
    {
        handleMovement();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
