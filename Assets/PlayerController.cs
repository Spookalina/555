using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbodyP;
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    [SerializeField]
    private float moveInput;

    private Animator anim;
    // Start is called before the first frame update

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigidbodyP = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rigidbodyP.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            anim.SetTrigger("Jumps");
        }
    }
    void CharacterAnimations()
    {
        if (moveInput == 0)
        {
            anim.SetBool("IsRunning", false);
        }

        else
        {
            anim.SetBool("IsRunning", true);
        }

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    void Update()
    {
        Jump();
        moveInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveInput, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        CharacterAnimations();
        
        if (isGrounded == true)
        {
            anim.SetBool("IsOnGround", true);
        }

        else if(isGrounded == false)
        {
            anim.SetBool("IsOnGround", false);
        }
    }
}
