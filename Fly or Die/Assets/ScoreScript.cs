using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public float score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        GetComponent<UnityEngine.UI.Text>().text = Mathf.Floor(score).ToString();
        
    }
}
