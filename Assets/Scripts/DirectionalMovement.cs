using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody rb;
    Vector3 movement;

    public Material playerMat;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
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

    void handleMaterial()
    {
        playerMat.mainTexture = spriteRenderer.sprite.texture;
        playerMat.SetTexture("PlayerTexture", spriteRenderer.sprite.texture);
        playerMat.SetTexture("_MainTex", spriteRenderer.sprite.texture);
        Debug.Log(spriteRenderer.sprite.texture);
        Debug.Log(playerMat.mainTexture);
    }

    void Update()
    {
        handleMovement();
        if (playerMat != null)
        {
            handleMaterial();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
