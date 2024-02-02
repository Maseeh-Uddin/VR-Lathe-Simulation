using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsaberController : MonoBehaviour
{
    public float swingSpeed = 5f;

    void Update()
    {
        // Example: Rotate the lightsaber based on mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Adjust the lightsaber's rotation based on input
        transform.Rotate(Vector3.up, mouseX * swingSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right, mouseY * swingSpeed * Time.deltaTime);

        // Example: Activate lightsaber with a key press (e.g., spacebar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateLightsaber();
        }
    }

    void ActivateLightsaber()
    {
        // Your code to handle lightsaber activation (e.g., play sound, enable visual effects, etc.)
        // You might want to call methods or modify variables in your Lightsaber script here.
    }
}
