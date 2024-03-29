﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
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
            float highScore = GameObject.Find("HighScore").GetComponent<HighScoreScript>().highScore;
            float currentScore = GameObject.Find("Score").GetComponent<ScoreScript>().score;

            if (currentScore > highScore) {
                GameObject.Find("HighScore").GetComponent<HighScoreScript>().highScore = Mathf.Floor(currentScore);
            }

            SceneManager.LoadScene("MainMenu");
        }
    }
}
