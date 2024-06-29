using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float jumpForce = 10.0f;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");

        if(moveX > 0.0f) spriteRenderer.flipX = false;
        else if(moveX < 0.0f) spriteRenderer.flipX = true;

        foreach (RaycastHit2D raycastHit2D in Physics2D.RaycastAll(transform.position, Vector2.down, 1.5f))
        {
            if (raycastHit2D.collider.CompareTag("Platform") && Input.GetButton("Jump"))
            {
                rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                animator.SetTrigger("Jump");
            }
        }

        rigidbody2D.velocity = new Vector2(moveX * speed, rigidbody2D.velocity.y);
        animator.SetFloat("Speed", rigidbody2D.velocity.magnitude);
    }
}
