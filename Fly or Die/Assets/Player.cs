using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;

    private bool isOnGround;
    private bool isGliding;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.freezeRotation = true;

        spriteRenderer = GetComponent<SpriteRenderer>();
        isOnGround = false;
        isGliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rigidBody2D.AddForce(Vector2.up * 24, ForceMode2D.Impulse);
            isOnGround = false;
        }

        if (Input.GetButton("Glide") && !isOnGround)
        {
            isGliding = true;
            rigidBody2D.drag = 10;
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/glide");
        }
        else
        {
            isGliding = false;
            rigidBody2D.drag = 0;
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/run");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ground"))
        {
            isOnGround = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Add a small continuous upwards force if the player is gliding through an updraft
        if(isGliding && collision.GetComponent<UpdraftScript>())
        {
            rigidBody2D.AddForce(Vector2.up * 1.25f, ForceMode2D.Impulse);
        }
    }
}
