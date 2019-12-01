using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyLightScript : MonoBehaviour
{
    private Light light;
    private float scaledTime;

    // Two colors to swap between
    private Color colorOne = new Color(0f, 0f, .25f, 1f);
    private Color colorTwo = new Color(.25f, 0f, 0f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        scaledTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Gradually interpolate back and forth between the two colors
        Color color = light.color;

        scaledTime += Time.deltaTime * .125f;
        color =  Color.Lerp(colorOne, colorTwo, Mathf.PingPong(scaledTime, 1));

        light.color = color;
    }
}
