using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
public float speed = 1.0f;
public float leftBound = -10.0f;
public float rightBound = 10.0f;
public float protectedArea = 5.0f;
private bool movingRight = true;
private float changeDirectionTime = 2.0f;
private float timeUntilDirectionChange = 1.0f;


void Move()
{
    if (timeUntilDirectionChange <= 0.0f)
    {
        movingRight = !movingRight;
        timeUntilDirectionChange = changeDirectionTime;
    }
    else
    {
        timeUntilDirectionChange -= Time.deltaTime;
    }

    if (movingRight)
    {
        if (transform.position.x + speed * Time.deltaTime > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
            movingRight = false;
        }
        else
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
    else
    {
        if (transform.position.x - speed * Time.deltaTime < leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
            movingRight = true;
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}
}