using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newScaling : MonoBehaviour
{
    // Start is called before the first frame update
    public float startDelay = 57f;   // Delay before scaling starts (in seconds)
    public float duration = 15f;    // Total duration of scaling (in seconds)
    public Vector3 scaleChange = new Vector3(0, -0.001f, 0);

    private float elapsedTime = 0f;

    void Update()
    {
        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // Check if it's time to start scaling
        if (elapsedTime >= startDelay && elapsedTime <= startDelay + duration)
        {
            // Apply the scale change during the specified duration
            transform.localScale += scaleChange * Time.deltaTime;
        }
    }
}
