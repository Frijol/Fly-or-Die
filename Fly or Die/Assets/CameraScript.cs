using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;
    private Vector3 cameraStartPosition;

    // Y-values of the ground and the boundaries between layers.
    // Camera will change when player goes above or below the boundaries.
    private float groundPosition = -4.5f;
    private float firstLayerBoundary = -0.50f;
    private float secondLayerBoundary = 2.771f;

    // Current layer that the player is in
    private int layer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        cameraStartPosition = transform.position;

        layer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (layer == 1)
        {
            // If player moves above top of screen, move camera up
            if (player.transform.position.y >= firstLayerBoundary)
            {
                transform.position = cameraStartPosition + new Vector3(0f, firstLayerBoundary - groundPosition, 0f);
                layer = 2;
            }
        }
        else if (layer == 2)
        {
            // If player moves below bottom of screen, move camera down
            if (player.transform.position.y < firstLayerBoundary)
            {
                transform.position = cameraStartPosition;
                layer = 1;
            }
            // If player moves above top of screen, move camera up
            else if (player.transform.position.y >= secondLayerBoundary)
            {
                transform.position = cameraStartPosition + new Vector3(0f, secondLayerBoundary - groundPosition, 0f);
                layer = 3;
            }
        }
        else if (layer == 3)
        {
            // If player moves below bottom of screen, move camera down
            if (player.transform.position.y < secondLayerBoundary)
            {
                transform.position = cameraStartPosition + new Vector3(0f, firstLayerBoundary - groundPosition, 0f);
                layer = 2;
            }
        }
    }
}
