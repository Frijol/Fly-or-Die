using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeScript : MonoBehaviour
{
    public float speed;
    private Collider2D[] playerColliders;
    private Collider2D ledgeCollider;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch player and ledge colliders
        playerColliders = GameObject.FindWithTag("Player").GetComponents<Collider2D>();
        ledgeCollider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // Move left
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Collision ignored when ledge is above player
        float bottomOfPlayer = playerColliders[0].bounds.min.y;
        bool ignoreCollisionWithPlayer = transform.position.y >= bottomOfPlayer ? true : false;

        foreach(Collider2D collider in playerColliders)
            Physics2D.IgnoreCollision(ledgeCollider, collider, ignoreCollisionWithPlayer);
    }
}
