using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movment : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public float moveSpeed = 8;
    public float playerjumpforce = 8;
    private bool floor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && floor)
        {
            Debug.Log("space");
            myrigidbody.velocity = Vector2.up * playerjumpforce;
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        floor = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        floor = false;
    }
}
