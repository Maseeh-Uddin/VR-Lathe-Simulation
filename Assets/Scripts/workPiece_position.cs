using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workPiece_position : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 0, 0); // Adjust the offset as needed
    private GameObject Cylinder;
    private Vector3 scaleChange, positionChange;
    void Start()
    {
        Debug.Log("started.");
        // Set the workpiece position inside the chuck
        SetWorkpiecePosition();
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        if (meshFilter != null)
        {
            // Get the Mesh from the MeshFilter
            Mesh mesh = meshFilter.mesh;

            // Get all vertices of the mesh
            Vector3[] vertices = mesh.vertices;

            // Print or process the vertices
            for (int i = 0; i < vertices.Length; i++)
            {
                Debug.Log("Vertex " + i + ": " + vertices[i][1]);

            }
        }
        else
        {
            Debug.LogError("MeshFilter component not found.");
        }
    }
    void Awake()
    {
        scaleChange = new Vector3(0.0005f, 0.001f, 0.0005f);
    }
        void Update()
    {
       
    }
    void SetWorkpiecePosition()
    {
        // Set the local position of the workpiece relative to the chuck
        transform.localPosition = offset;
    }
}
