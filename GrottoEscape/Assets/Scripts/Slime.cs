using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyController
{
    //-----------------------------------------------------------------//
    // MONOBEHAVIOUR FUNCTIONS

    private void Start ()
    {
        this.SetHealth (2);
        this.SetMoveSpeed (2);
        this.SetDistanceToAttack (3f);
    }

    private void Update () 
    {
        float currentDistance = this.CalculatePlayerDistance ();
        this.SetIsMoving ((currentDistance <= this.GetDistanceToAttack ()));

        if (this.GetIsMoving ())
        {
            if ((player.position.x > this.transform.position.x && spriteRenderer.flipX) || 
                (player.position.x < this.transform.position.x && !spriteRenderer.flipX))
            {
                this.FlipSprite ();
            }
        }
    }

    private void FixedUpdate () 
    {
        if (this.GetIsMoving ())
        {
            rigidBody2D.velocity = new Vector2 (this.GetMoveSpeed (), rigidBody2D.velocity.y);    
        }
        else
        {
            rigidBody2D.velocity = new Vector2 (0f, rigidBody2D.velocity.y);
        }
    }
}