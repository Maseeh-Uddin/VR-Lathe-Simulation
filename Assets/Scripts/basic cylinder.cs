using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basiccylinder : MonoBehaviour
{
    private GameObject cylinderObject;
    private float initialRadius = 1.0f; // Initial radius of the cylinder

    void Start()
    {
        CreateCylinder();
    }

    void Update()
    {
        // Check for user input to modify the radius during runtime
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            IncreaseRadius();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DecreaseRadius();
        }
    }

    void CreateCylinder()
    {
        // Create a new cylinder GameObject
        cylinderObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        Destroy(cylinderObject.GetComponent<Collider>()); // Remove the collider to avoid blocking the view
        cylinderObject.transform.position = Vector3.zero; // Set the position as per your requirements
        UpdateCylinderScale();
    }

    void IncreaseRadius()
    {
        // Increase the radius and update the cylinder scale
        initialRadius += 0.1f; // You can adjust the increment value as per your preference
        UpdateCylinderScale();
    }

    void DecreaseRadius()
    {
        // Decrease the radius and update the cylinder scale
        if (initialRadius > 0.1f) // Ensure the radius doesn't go below a certain threshold
        {
            initialRadius -= 0.1f; // You can adjust the decrement value as per your preference
            UpdateCylinderScale();
        }
    }

    void UpdateCylinderScale()
    {
        cylinderObject.transform.localScale = new Vector3(initialRadius * 2, 1.0f, initialRadius * 2);
    }
}
