using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class normal_enemy : MonoBehaviour
{
    public bool isFliept;
    public float speed = 2f;
    private bool facingRight = false;
    public LayerMask groundLayer;
    public int angle = 40;
    private SpriteRenderer spriteRenderer;
    public ParticleSystem deathEffect;
    private sound_Manager soundManager;
    public int playerDamage = 3;
    public int playerDamage_1 = 2;
    public int Maxhealth = 10;
    public int currenthealth;
    private coin_logic coinLogic;


    public healthbarscript healthbar;

    void Start()
    {
        //Debug.Log("Lets go");
        currenthealth = Maxhealth;
        healthbar.SetMaxHealth(Maxhealth);
        soundManager = FindObjectOfType<sound_Manager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        healthbar = GetComponent<healthbarscript>();
        coinLogic = FindObjectOfType<coin_logic>();
    }


    void Update()
    {

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


            if (currenthealth <= 0)
            {
                soundManager.Play("enemy_death");
                deathEffect.Play();
                coinLogic.addenemy();
                Destroy(gameObject);
            }

        }
    }
}


