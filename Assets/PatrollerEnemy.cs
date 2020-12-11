using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollerEnemy : EnemyClass
{
    private bool movingRight = true;
    public Transform groundDetector;
    private RaycastHit2D groundRay;

    public override void Movement()
    {
        groundRay = Physics2D.Raycast(groundDetector.position, Vector2.down, 2f);
        directionVector = new Vector3(direction, 0);

        if (movingRight == true)
        {
            direction = -1;       
        }
        else
        {
            direction = 1;
        }
        base.Movement();
    }
    public override void MovementRotation()
    {
        if (groundRay.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}

