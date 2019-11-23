using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdraftScript : MonoBehaviour
{
    public float speed;
    private Collider2D[] playerColliders;
    private Collider2D updraftCollider;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch player and updraft colliders
        playerColliders = GameObject.FindWithTag("Player").GetComponents<Collider2D>();
        updraftCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
