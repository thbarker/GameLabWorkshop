using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpPower = 16f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpPower);
        }
    }

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(horizontal*speed, rigidBody.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
