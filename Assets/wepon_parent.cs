using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepon_parent : MonoBehaviour
{
    public Vector2 pointer_position { get; set; }

    private void Update()
    {
        pointer_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = (pointer_position - (Vector2)transform.position).normalized;
    }


}
