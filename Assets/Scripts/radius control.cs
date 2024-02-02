using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radiuscontrol : MonoBehaviour
{
    private GameObject cylinderObject;
    private float initialRadius = 1.0f; // Initial radius of the cylinder

    void Start()
    {
        CreateCylinder();
        //gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }

    void Update()
    {
        // Check for user input to modify the radius during runtime
        if (Input.GetKey(KeyCode.UpArrow))
        {
            IncreaseRadius();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            DecreaseRadius();
        }
    }
    //MeshRenderer smallCylinderRenderer = smallCylinder.GetComponent<MeshRenderer>();
    //smallCylinderRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    void CreateCylinder()
    {
        // Create a new cylinder GameObject
        cylinderObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinderObject.transform.position = new Vector3(0,yPositionDecider()*2,0); // Set the position as per your requirements
        cylinderObject.transform.localScale = new Vector3(initialRadius * 2, 1.0f, initialRadius * 2);
        SetRandomColor();
    }

    void IncreaseRadius()
    {
        // Increase the radius and update the cylinder scale
        initialRadius += 0.1f; // You can adjust the increment value as per your preference
        cylinderObject.transform.localScale = new Vector3(initialRadius * 2, 1.0f, initialRadius * 2);
    }

    void DecreaseRadius()
    {
        // Decrease the radius and update the cylinder scale
        if (initialRadius > 0.1f) // Ensure the radius doesn't go below a certain threshold
        {
            initialRadius -= 0.1f; // You can adjust the decrement value as per your preference
            cylinderObject.transform.localScale = new Vector3(initialRadius * 2, 1.0f, initialRadius * 2);
        }
    }
    int yPositionDecider()
    {
        // Access the character at index 16 of the GameObject's name and convert it to an integer
        if (gameObject.name.Length > 16)
        {
            char characterAtIndex16 = gameObject.name[16];

            // Using int.Parse
            int convertedValue = int.Parse(characterAtIndex16.ToString());

            // OR using System.Convert.ToInt32
            // int convertedValue = System.Convert.ToInt32(characterAtIndex16);
            Debug.Log("Character at index 16 as integer: " + convertedValue);
            return convertedValue;
        }
        else
        {
            return -1;
        }
    }
    void SetRandomColor()
    {
        // Set a random color to the cylinder
        Renderer cylinderRenderer = cylinderObject.GetComponent<Renderer>();
        if (cylinderRenderer != null)
        {
            cylinderRenderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
