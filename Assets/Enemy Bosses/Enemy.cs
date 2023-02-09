using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    public float leftBound = -10.0f;
    public float rightBound = 10.0f;
    private bool movingRight = true;

    void Update()
    {
        if (transform.position.x >= rightBound)
        {
            movingRight = false;
        }
        else if (transform.position.x <= leftBound)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}