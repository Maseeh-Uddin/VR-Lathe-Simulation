using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel1rotate : MonoBehaviour
{
    // Start is called before the first frame update
    // Rotation speed in degrees per second
    public float rotationSpeed = 30f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for user input
        float rotationInput = Input.GetAxis("Horizontal");

        // Calculate rotation angle based on input
        float rotationAngle = rotationInput * rotationSpeed * Time.deltaTime;

        // Rotate the wheel
        transform.Rotate(Vector3.up, rotationAngle);
    }

}
