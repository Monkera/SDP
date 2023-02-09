using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wepon_parent : MonoBehaviour
{
    private Collider2D _collider2D;
    public Vector2 pointer_position { get; set; }
    private Animator _animator;
    private GameObject child;

    private void Start()
    {
        child = transform.GetChild(0).gameObject;
        _collider2D = child.GetComponent<Collider2D>();
        _animator = child.GetComponent<Animator>();
    }
    

    private void Update()
    {
        pointer_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = (pointer_position - (Vector2)transform.position).normalized;

        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetBool("attack", true);
            _collider2D.enabled = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("attack", false);
            _collider2D.enabled = false;
        }
    }

    


}
