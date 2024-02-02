using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class another : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Get the position of the GameObject this script is attached to
        Vector3 spawnPosition = transform.position;

        // Create a new cylinder GameObject
        GameObject cylinderObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        // Add components or modify properties as needed
        // Set the position to the spawn position
        cylinderObject.transform.position = spawnPosition;

        // Set the rotation to have the axis along the z-axis
        cylinderObject.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

        // You can also adjust other properties like scale
        // cylinderObject.transform.localScale = new Vector3(1f, 2f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
