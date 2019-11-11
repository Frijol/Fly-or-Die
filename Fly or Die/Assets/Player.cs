using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void HandleInput() {
        if (Input.GetButtonDown("Jump")) {
            rigidBody2D.AddForce(Vector2.up * 16, ForceMode2D.Impulse);
        }
        if (Input.GetButton("Glide")) {
            rigidBody2D.drag = 10;
        } else {
            rigidBody2D.drag = 0;
        }
    }
}
