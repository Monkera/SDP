using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject gameManager;

    
    private void OnCollisonEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
        }
    }
}
