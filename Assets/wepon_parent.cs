using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepon_parent : MonoBehaviour
{
    private Collider2D _collider2D;
    public Vector2 pointer_position { get; set; }
    private Animator _animator;
    private GameObject child;
    private SpriteRenderer spriteRenderer;
    private bool isAttacking;
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
            if (PlayerPrefs.GetInt("direction") == 0)
            {
                spriteRenderer.flipX = false;
                child.transform.localPosition = new Vector3(0.3f, 0, 0);
            }
            else if (PlayerPrefs.GetInt("direction") == 1)
            {
                spriteRenderer.flipX = true;
                child.transform.localPosition = new Vector3(-0.3f, 0, 0);
            }
            spriteRenderer.enabled = true;
            _animator.SetBool("attack", true);
            _collider2D.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
            _collider2D.enabled = false;
            _animator.SetBool("attack", false);
        }
    }

}