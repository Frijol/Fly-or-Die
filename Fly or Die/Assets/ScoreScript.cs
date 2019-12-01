using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public float score;
    public float multiplier;

    void Start()
    {
        multiplier = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * multiplier;
        GetComponent<UnityEngine.UI.Text>().text = Mathf.Floor(score).ToString();
    }
}
