using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody rb;
    Vector3 movement;

    public Animator animator;
    void handleMovement()
    {
        movement.x = -Input.GetAxisRaw("Horizontal");
        movement.z = -Input.GetAxisRaw("Vertical");
        movement.Normalize();
        //Set Ani Variables
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
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
