using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth Playerhealth;

    private void OnCollisonEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {

        }
    }
}
