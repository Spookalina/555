using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [Range(0.2f,5f)]
    [SerializeField] private float movementSpeed = 1;
    private int health;
    [SerializeField] private int maxhealth = 1;
    private Vector2 pos;
    [SerializeField]
    [Range(-1,1)]
    protected int direction = -1;
    protected Vector3 directionVector;
    protected BoxCollider2D colliderbox2D;
    protected Rigidbody2D rigidbodyE;
    // Start is called before the first frame update
    public void Awake()
    {
        colliderbox2D = GetComponent<BoxCollider2D>();
        rigidbodyE = GetComponent<Rigidbody2D>();
        health = maxhealth;
        directionVector = new Vector3(direction,0);
    }

    public virtual void Movement()
    {
        transform.position += directionVector * movementSpeed * Time.deltaTime;
    }

    public virtual void MovementRotation()
    {
        if(direction < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        else if (direction > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public virtual void EnemyHealth()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    public void Update()
    {
        Movement();
        MovementRotation();
        EnemyHealth();
    }
}
