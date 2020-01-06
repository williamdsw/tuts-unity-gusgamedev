using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (other.CompareTag ("Portal"))
        {
            Destroy (other.gameObject);
            Invoke ("NextLevel", 3f);
        }
    }

    //-----------------------------------------------------------------//
    // HELPER FUNCTIONS

    private void NextLevel ()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }
}