using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    public float speed = 2.0f;
    public Transform target;

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;
        direction = direction.normalized;

        transform.position += direction * speed * Time.deltaTime;
    }
}
