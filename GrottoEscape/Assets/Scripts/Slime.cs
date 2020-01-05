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
        this.SetMoveSpeed (2f);
        this.SetDistanceToAttack (3f);
    }

    protected override void Update () 
    {
        base.Update ();
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