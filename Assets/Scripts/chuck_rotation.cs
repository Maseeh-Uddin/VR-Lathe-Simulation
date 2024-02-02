using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class chuck_rotation : MonoBehaviour
{
    public float rotationSpeed = 50.0f;  // Adjust the speed of rotation as needed
    private bool isSpindleRotating = false;

    void Update()
    {
   
        // Check for user input to start/stop spindle rotation
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Toggle the rotation state
            isSpindleRotating = !isSpindleRotating;
        }

        // Rotate the chuck if it's set to rotate
        if (isSpindleRotating)
        {
            RotateChuck();
        }
    }

    void RotateChuck()
    {
        // Rotate the chuck around its own local Y-axis

        Vector3 Pivot = transform.position;
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime*15);
    }
    void OnDrawGizmos()
    {
        // Set the color for the gizmo (you can customize this)
        Gizmos.color = Color.red;

        // Draw a sphere at the origin position
        Gizmos.DrawSphere(Vector3.zero, 0.1f);
    }
}
