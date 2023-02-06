using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 500f;
    public Rigidbody2D rigidbody2D;
    
    private bool isGrounded;


    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 velocity = rigidbody2D.velocity;
        velocity.x = horizontal * speed;
        rigidbody2D.velocity = velocity;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
