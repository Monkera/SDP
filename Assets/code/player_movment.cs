using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movment : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public Animator anim;
    public float moveSpeed = 8;
    public float playerjumpforce = 8;
    private bool floor;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

    private void runIfPossible()
    {
        if (floor)
        {
            anim.SetBool("is_running", true);
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        floor = true;
        anim.SetBool("is_jumping", false);

        if (collision.gameObject.tag == "spikes")
        {
            gameOver.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        floor = false;
    }



}
