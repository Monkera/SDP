using System.Collections;
using UnityEngine;

public class normal_enemy : MonoBehaviour
{
    public float speed = 2f;
    private bool facingRight = false;
    private Rigidbody2D rb;
    public LayerMask groundLayer;
    public int angle = 40;
    private SpriteRenderer spriteRenderer;
    public ParticleSystem deathEffect;
    private sound_Manager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<sound_Manager>();
        deathEffect = GetComponent<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (facingRight)
        {
            spriteRenderer.flipX = false;
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            spriteRenderer.flipX = true;
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        Vector2 direction = facingRight ? new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), -Mathf.Cos(angle * Mathf.Deg2Rad)) : new Vector2(-Mathf.Sin(angle * Mathf.Deg2Rad), -Mathf.Cos(angle * Mathf.Deg2Rad));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, groundLayer);

        Debug.DrawRay(transform.position, direction, Color.red);
        if (hit.collider == null)
        {
            facingRight = !facingRight;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sword")
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            soundManager.Play("enemy_death");
        }
    }
}
