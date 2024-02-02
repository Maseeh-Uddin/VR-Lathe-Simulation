using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alternatescalingnew : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tool;
    public float scalingSpeed = 0.1f;

    private float initialToolPositionZ;
    private Vector3 originalScale;

    private float maxDeltaDistance = float.MinValue;
    // Start is called before the first frame update
    void Start()
    {
        if (tool != null)
        {
            // Set the initial position of the tool for reference
            initialToolPositionZ = tool.position.z;

            // Store the original scale of the cylinder
            originalScale = transform.localScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tool != null && ((Input.GetKey(KeyCode.A)) && tool.position.z - initialToolPositionZ > maxDeltaDistance))
        {
            // Calculate the change in distance between frames in the Z-axis
            float deltaDistance = tool.position.z - initialToolPositionZ;
            // Update minDeltaDistance
            maxDeltaDistance = Mathf.Max(maxDeltaDistance, deltaDistance);

            // Calculate the desired scale with respect to the original scale
            float targetScale = Mathf.Abs(originalScale.y - deltaDistance * scalingSpeed *(float)(1.62) );

            // Apply the new scale to the cylinder abruptly
            transform.localScale = new Vector3(originalScale.x, targetScale, originalScale.z);
        }
    }
}
