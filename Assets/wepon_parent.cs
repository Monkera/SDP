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
    private SpriteRenderer spriteRenderer;
    private bool isattacking;

    private void Start()
    {
        child = transform.GetChild(0).gameObject;
        spriteRenderer = child.GetComponent<SpriteRenderer>();
        _collider2D = child.GetComponent<Collider2D>();
        _animator = child.GetComponent<Animator>();
    }
    

    private void Update()
    {

        if (Input.GetKey("x"))
        {
            spriteRenderer.enabled = true;
            _animator.SetBool("attack", true);
            _collider2D.enabled = true;
            //_animator.
        }

        
        
    }

    


}
