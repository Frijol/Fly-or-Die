using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeScript : MonoBehaviour
{
    public float speed;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch player reference
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Move left
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Collider only enabled when below player
        float bottomOfPlayer = player.GetComponent<Collider2D>().bounds.min.y;
        GetComponent<Collider2D>().enabled = transform.position.y <= bottomOfPlayer ? true : false;
    }
}
