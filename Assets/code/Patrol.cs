using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 2f;
    public float patrolDistance = 3f;

    private float originalX;
    private bool movingRight = true;



    private void Start()
    {
        originalX = transform.position.x;
    }

    private void Update()
    {
        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

            if (transform.position.x >= originalX + patrolDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

            if (transform.position.x <= originalX - patrolDistance)
            {
                movingRight = true;
            }
        }  
    }
}
