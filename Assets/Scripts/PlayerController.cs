using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpPower = 16f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform rightGroundCheck;
    [SerializeField] private Transform leftGroundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        EnablePlayerMovement();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            rigidBody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(horizontal*speed, rigidBody.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(rightGroundCheck.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(leftGroundCheck.position, 0.2f, groundLayer);
    }

    private void DisablePlayerMovement()
    {
        rigidBody.bodyType = RigidbodyType2D.Static;
    }

    private void EnablePlayerMovement()
    {
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnEnable()
    {

        DeathBarrier.OnPlayerDeath += DisablePlayerMovement;
    }
    private void OnDisable()
    {
        DeathBarrier.OnPlayerDeath -= DisablePlayerMovement;
    }
}
