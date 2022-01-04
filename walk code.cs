using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    #region Regulars variables
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    bool canJump;
    #endregion



    #region Components
    Rigidbody2D rb;
    #endregion
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
        detectGround();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 mov = new Vector2(Input.GetAxis("Horizontal"), 0);

        if(mov != Vector2.zero) 
        {
            rb.position += mov * speed * Time.fixedDeltaTime;
        }
    }
    
    void Jump()
    {
        
        if(canJump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity += Vector2.up * jumpForce;
            }
        }
    }

    void detectGround()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, .3f, LayerMask.GetMask("Ground")))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }
}
