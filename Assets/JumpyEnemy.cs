using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpyEnemy : EnemyClass
{
    [SerializeField]
    private LayerMask groundLayerMask;
    [SerializeField]
    private Transform groundDetector;
    [SerializeField]
    private float timer = 0;
    [SerializeField]
    private bool isGrounded()
    {
        float marginOfError = .03f;
        RaycastHit2D raycastHit = Physics2D.Raycast(colliderbox2D.bounds.center, Vector2.down, colliderbox2D.bounds.extents.y + marginOfError, groundLayerMask);
        return raycastHit.collider != null;
    }

    private void EnemyJump()
    { 
        float finishTimer = 3;
        timer += Time.deltaTime;
        if (timer >= finishTimer)
        {
            Debug.Log("Funciona");
            timer = 0;
            if (isGrounded() == true)
            {
                rigidbodyE.AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
            }

        }
    }
    public override void Movement()
    {
        base.Movement();
        EnemyJump();
    }
}
