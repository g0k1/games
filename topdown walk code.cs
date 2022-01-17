using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 mov = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (mov != Vector2.zero)
        {
            rb.position += mov * speed * Time.fixedDeltaTime;
        }
    }
}

