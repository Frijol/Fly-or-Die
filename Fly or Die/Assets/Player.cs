using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void HandleInput() {
        if (Input.GetButtonDown("Jump")) {
            rigidBody2D.AddForce(Vector2.up * 24, ForceMode2D.Impulse);
        }
        if (Input.GetButton("Glide")) {
            rigidBody2D.drag = 10;
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/glide");

        } else {
            rigidBody2D.drag = 0;
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/run");
        }
    }
}
