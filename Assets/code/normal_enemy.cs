using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class normal_enemy : MonoBehaviour
{
    public bool isFliept;
    public float speed = 2f;
    private bool facingRight = false;
    //private Rigidbody2D rb;
    public LayerMask groundLayer;
    public int angle = 40;
    private SpriteRenderer spriteRenderer;
    public ParticleSystem deathEffect;
    private sound_Manager soundManager;
      public int playerDamage = 5;
      public int playerDamage_1 = 2;
    public int Maxhealth = 10;
    public int currenthealth;
   

    public healthbarscript healthbar;

    void Start()
    {
        Debug.Log("Lets go");
        currenthealth = Maxhealth;
        healthbar.SetMaxHealth(Maxhealth);
        soundManager = FindObjectOfType<sound_Manager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        healthbar = GetComponent<healthbarscript>();
         
    }


    void Update()
    {

        /*if (facingRight)
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
        }*/

        Vector2 direction = facingRight ? new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), -Mathf.Cos(angle * Mathf.Deg2Rad)) : new Vector2(-Mathf.Sin(angle * Mathf.Deg2Rad), -Mathf.Cos(angle * Mathf.Deg2Rad));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, groundLayer);

        Debug.DrawRay(transform.position, direction, Color.red);
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "sword")
        {
            currenthealth -= playerDamage;
            healthbar.SetHealth(currenthealth);


            if(currenthealth <= 0) {
               soundManager.Play("enemy_death");
            deathEffect.Play();
            Destroy(gameObject);

            }
            
        }
       
      

    }
}

    
