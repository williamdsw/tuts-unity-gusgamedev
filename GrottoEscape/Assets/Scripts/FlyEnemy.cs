using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : EnemyController
{
    //-----------------------------------------------------------------//
    // MONOBEHAVIOUR FUNCTIONS

    protected override void Update ()
    {
        base.Update ();

        if (this.GetIsMoving ())
        {
            this.transform.position = Vector3.MoveTowards (this.transform.position, player.position, Mathf.Abs (this.GetMoveSpeed ()) * Time.deltaTime);    
        }
    }
}
