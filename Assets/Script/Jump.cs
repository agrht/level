using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float moveSpeed;
    float xInput, yInput;

    Rigidbody2D rb;

    SpriteRenderer sp;

    public float jumpForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp= GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumper();
        }
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0);
        PlatformerMove();
        FlipPlayer();
    }

    void Jumper()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    void PlatformerMove()
    {
        rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);
    }

    void FlipPlayer()
    {
        if (rb.velocity.x<-0.1f)
        {
            sp.flipX = true;
        }
        else if (rb.velocity.x>0.1f)
        {
            sp.flipX = false;
        }
    }
}
