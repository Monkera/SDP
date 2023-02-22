using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movment : MonoBehaviour
{
    private bool key;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Animator _animator;
    public float MoveSpeed = 7f;
    public float PlayerJumpForce = 5f;
    private bool _isFloor;
    public float ClimbSpeed = 8f;
    private bool _isClimbing;
    private sound_Manager soundManager;
    private coin_logic coinLogic;
    public int enemyDamage = 2;
    public int spikeDamage = 10;
    public int Maxhealth = 10;
    public int currenthealth;
    private bool isBouncing = false;

    public healthbarscript healthbar;

    void Start()
    {
        currenthealth = Maxhealth;
        healthbar.SetMaxHealth(Maxhealth);
    }

    private void Awake()
    {
        coinLogic = FindObjectOfType<coin_logic>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        soundManager = FindObjectOfType<sound_Manager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        healthbar = GetComponent<healthbarscript>();
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
            if (horizontalInput < 0)
            {
                spriteRenderer.flipX = true;
                PlayerPrefs.SetInt("direction", 1);
            }
            else if (horizontalInput > 0)
            {
                spriteRenderer.flipX = false;
                PlayerPrefs.SetInt("direction", 0);
            }
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
            soundManager.Play("jump");
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

        
        if (collision.gameObject.tag == "enemy")
        {
            currenthealth -= enemyDamage;
            healthbar.SetHealth(currenthealth);
            Debug.Log(currenthealth);

            isBouncing = true;
            float bounce = 150f; //amount of force to apply
            _rigidbody2D.AddForce(collision.contacts[0].normal * bounce);

            Invoke("StopBounce", 0.3f);

            if (currenthealth <= 0)
            {

                over();

            }


        }
    }

    private void over()
    {
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        soundManager.Play("death");
        FindObjectOfType<GameManager>().GameOver();
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
        else if (collider.gameObject.tag == "key")
        {
            soundManager.Play("key_pickup");
            Debug.Log("Key");
            key = true;
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.tag == "Door" && key == true)
        {
            soundManager.Play("door");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collider.gameObject.tag == "coin")
        {
            coinLogic.addcoin();
            soundManager.Play("coin");
            Destroy(collider.gameObject);

        }
        else if (collider.gameObject.tag == "chest")
        {
            coinLogic.addchest();
            soundManager.Play("chest");
            Destroy(collider.gameObject);
        }else if (collider.gameObject.tag == "spikes")
        {
            over();
            Destroy(gameObject);
            soundManager.Play("death");
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ladder")
        {
            _isClimbing = false;
        }
    }


    void StopBounce()
    {
        isBouncing = false;
    }
}