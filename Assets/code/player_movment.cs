using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movment : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    public float MoveSpeed = 7f;
    public float PlayerJumpForce = 5f;
    private bool _isFloor;
    public float ClimbSpeed = 8f;
    private bool _isClimbing;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveHorizontally();
        Jump();
        Climb();
    }

    private void MoveHorizontally()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalInput) > Mathf.Epsilon)
        {
            RunIfPossible();
            transform.Translate(Vector2.right * horizontalInput * MoveSpeed * Time.deltaTime);
        }
        else
        {
            _animator.SetBool("is_running", false);
        }
    }

    private void RunIfPossible()
    {
        if (_isFloor)
        {
            _animator.SetBool("is_running", true);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isFloor)
        {
            _animator.SetBool("is_jumping", true);
            _rigidbody2D.velocity = Vector2.up * PlayerJumpForce;
        }
    }

    private void Climb()
    {
        if (_isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical");
            _rigidbody2D.velocity = new Vector2(0, verticalInput * ClimbSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isFloor = true;
        _animator.SetBool("is_jumping", false);

        if (collision.gameObject.tag == "spikes")
        {
            SceneManager.LoadScene("UI_Game_Over");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isFloor = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ladder")
        {
            Debug.Log("Ladder");
            _isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ladder")
        {
            _isClimbing = false;
        }
    }
}
