using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movment : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public Animator anim;
    public float moveSpeed = 8;
    public float playerjumpforce = 8;
    private bool floor;
    public float climbSpeed = 2.0f;
    private bool onLadder = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (onLadder)
        {
            float vertical = Input.GetAxisRaw("Vertical");
            transform.Translate(Vector2.up * vertical * climbSpeed * Time.deltaTime);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                runIfPossible();
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                runIfPossible();
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("is_running", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && floor)
            {
                anim.SetBool("is_jumping", true);
                myrigidbody.velocity = Vector2.up * playerjumpforce;
            }
        }
    }

    private void runIfPossible()
    {
        if (floor)
        {
            anim.SetBool("is_running", true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            onLadder = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        floor = true;
        
        if (collision.gameObject.tag == "spikes")
        {
            SceneManager.LoadScene("UI_Game_Over");
        }
        else if (collision.gameObject.tag == "leader")
        {
            Debug.Log("leader");
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("is_jumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        floor = false;
    }
}
