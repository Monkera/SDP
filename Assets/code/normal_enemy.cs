using System.Collections;
using UnityEngine;

public class normal_enemy : MonoBehaviour
{
    public bool isFliept;
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
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (facingRight)
        {
            spriteRenderer.flipX = false;
            isFliept = true;
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            spriteRenderer.flipX = true;
            isFliept = false;
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        // what ever you do if you touch this line evretying will break so do not touch it
        Vector2 direction = facingRight ? new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), -Mathf.Cos(angle * Mathf.Deg2Rad)) : new Vector2(-Mathf.Sin(angle * Mathf.Deg2Rad), -Mathf.Cos(angle * Mathf.Deg2Rad));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, groundLayer);

        Debug.DrawRay(transform.position, direction, Color.red);
        if (hit.collider == null)
        {
            facingRight = !facingRight;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sword")
        {
            soundManager.Play("enemy_death");
            deathEffect.Play();
            Destroy(gameObject);
        }
    }
}
