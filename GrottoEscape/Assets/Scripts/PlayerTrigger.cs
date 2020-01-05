using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    //-----------------------------------------------------------------//
    // FIELDS

    private Player player;

    //-----------------------------------------------------------------//
    // MONOBEHAVIOUR FUNCTIONS

    private void Awake () 
    {
        player = this.GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.CompareTag ("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (!player.GetIsInvunerable ())
            {
                player.InflictDamage (enemy.GetDamage ());
            }
        }
    }
}