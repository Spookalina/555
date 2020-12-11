using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayEnemy : EnemyClass
{
    [SerializeField]
    private GameObject player;
    private float distanceFromPlayer;

    
    private void DestroyOutOfSight()
    {
        distanceFromPlayer = Vector3.Distance(player.transform.position, transform.position);
        
        if (distanceFromPlayer > 20)
        {
            Destroy(this.gameObject);
        }
    }

    public override void EnemyHealth()
    {
        base.EnemyHealth();
        DestroyOutOfSight();
    }
}
