using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth Playerhealth;

    private void OnCollisonEnter2D(Collison2D collision)
    {
        if(collision.gameObject.tag == "Player")
    {
        
    }
}
