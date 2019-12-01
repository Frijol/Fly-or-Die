using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    public float highScore;

    private static HighScoreScript instance;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
