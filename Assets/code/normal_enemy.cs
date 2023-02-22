using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class normal_enemy : MonoBehaviour
{
    public bool isFlipped;
    public float speed = 2f;
    private bool facingRight = false;
    private Rigidbody2D rb;
    public LayerMask groundLayer;
    public int angle = 40;
    private SpriteRenderer spriteRenderer;
    public ParticleSystem deathEffect;
    private sound_Manager soundManager;
    public int playerDamage = 5;
    public int playerDamage_1 = 2;
    public int Maxhealth = 10;
    public int currentHealth;

    public healthbarscript healthBar;


    private void Awake()
    {
        healthBar = GetComponent<healthbarscript>();
        currentHealth = Maxhealth;
        healthBar.SetMaxHealth(Maxhealth);
        soundManager = FindObjectOfType<sound_Manager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (facingRight)
        {
            spriteRenderer.flipX = false;
            isFlipped = true;
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            spriteRenderer.flipX = true;
            isFlipped = false;
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        Vector2 direction = facingRight ? new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), -Mathf.Cos(angle * Mathf.Deg2Rad)) : new Vector2(-Mathf.Sin(angle * Mathf.Deg2Rad), -Mathf.Cos(angle * Mathf.Deg2Rad));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, groundLayer);

        Debug.DrawRay(transform.position, direction, Color.red);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("sword"))
        {
            currentHealth -= playerDamage;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                soundManager.Play("enemy_death");
                deathEffect.Play();
                Destroy(gameObject);
            }
        }
    }
}
