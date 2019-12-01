using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;
    private ScoreScript scoreScript;
    private Vector3 cameraStartPosition;

    // Y-values of the ground and the boundaries between layers.
    // Camera will change when player goes above or below the boundaries.
    private float groundPosition = -3.966689f;
    private float firstLayerBoundary = -0.50f;
    private float secondLayerBoundary = 2.771f;

    // Current layer that the player is in
    private int layer;
    // Height the camera should gradually move to
    private float targetHeight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        scoreScript = GameObject.Find("Score").GetComponent<ScoreScript>();
        cameraStartPosition = transform.position;

        layer = 1;
        targetHeight = cameraStartPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        // make the camera follow the player if they get too far away
        float playerHeightDiff = player.transform.position.y - transform.position.y;
        if (Mathf.Abs(playerHeightDiff) > 1.75f)
        {
            targetHeight = transform.position.y + playerHeightDiff;
        }

        // Camera should snap to a layer if the player goes beyond the layer boundary
        if (layer == 1)
        {
            // if Player is on ground, reset sreen position
            if (player.transform.position.y < groundPosition + .1f)
            {
                targetHeight = cameraStartPosition.y;
            }
            // If player moves above top of screen, move camera up
            else if (player.transform.position.y >= firstLayerBoundary)
            {
                layer = 2;
                scoreScript.scoreMultiplier = 2f;
            }
        }
        else if (layer == 2)
        {
            // If player moves below bottom of screen, move camera down
            if (player.transform.position.y < firstLayerBoundary)
            {
                layer = 1;
                scoreScript.scoreMultiplier = 1f;
            }
            // If player moves above top of screen, move camera up
            else if (player.transform.position.y >= secondLayerBoundary)
            {
                layer = 3;
                scoreScript.scoreMultiplier = 3f;
            }
        }
        else if (layer == 3)
        {
            // If player moves below bottom of screen, move camera down
            if (player.transform.position.y < secondLayerBoundary)
            {
                layer = 2;
                scoreScript.scoreMultiplier = 2f;
            }
        }

        // Gradually move camera toward target height
        float targetHeightDiff = targetHeight - transform.position.y;
        if (!Mathf.Approximately(0f, targetHeightDiff))
        {
            transform.position += new Vector3(0f, Mathf.Min(Mathf.Abs(targetHeightDiff), .13f) * Mathf.Sign(targetHeightDiff), 0f);
        }
    }
}
