using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchScene(string newScene)
    {
        if (newScene != null)
        {
            SceneManager.LoadScene (newScene);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
