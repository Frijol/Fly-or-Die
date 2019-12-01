using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Arnett") {
            var scoreScript = GameObject.Find("Score").GetComponent<ScoreScript>();
            scoreScript.score += 10; // Score will be doubled because the player has two colliders
            Destroy(transform.gameObject);
        }
    }
}
