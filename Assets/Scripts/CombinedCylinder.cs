using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedCylinder : MonoBehaviour
{
    public int cylinderCount = 1000;
    public float smallCylinderHeight = 0.01f; // Adjust this value based on your requirements
    public float combinedCylinderRadius = 0.5f;
    public Material cylinderMaterial; // Assign a material in the Inspector

    void Start()
    {
        Debug.Log("entered");

        GenerateCombinedCylinder();
    }

    void GenerateCombinedCylinder()
    {
        GameObject combinedCylinder = new GameObject("CombinedCylinder");
        MeshFilter meshFilter = combinedCylinder.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = combinedCylinder.AddComponent<MeshRenderer>();
        meshRenderer.material = cylinderMaterial;

        float totalCylinderWidth = smallCylinderHeight *100f;

        for (int i = 0; i < cylinderCount; i++)
        {
            GameObject smallCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            smallCylinder.transform.parent = combinedCylinder.transform;

            float cylinderSpacing = totalCylinderWidth / cylinderCount;

            // Set small cylinder properties
            smallCylinder.transform.localScale = new Vector3(totalCylinderWidth / cylinderCount, smallCylinderHeight, totalCylinderWidth / cylinderCount);
            smallCylinder.transform.localPosition = new Vector3(cylinderSpacing * i - combinedCylinderRadius, 0f, 0f);
            smallCylinder.transform.rotation = Quaternion.Euler(0f, 0f, 90f);

            // Assign a random color to the small cylinder
            //MeshRenderer smallCylinderRenderer = smallCylinder.GetComponent<MeshRenderer>();
            //smallCylinderRenderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
