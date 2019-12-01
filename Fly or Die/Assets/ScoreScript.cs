using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public float score;
    public float scoreMultiplier;

    void Start()
    {
        scoreMultiplier = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * scoreMultiplier;
        GetComponent<UnityEngine.UI.Text>().text = $"Score: {Mathf.Floor(score).ToString()} \n Multiplier: {scoreMultiplier}x";
    }
}
