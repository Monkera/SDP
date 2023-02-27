using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    private float rotY;
    public float rotationSpeed = 100f;
    void Start()
    {
        
    }

    void Update()
    {
            rotY += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Euler(0, rotY, 0);
    }
}
