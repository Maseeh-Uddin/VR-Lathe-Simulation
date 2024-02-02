using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class meshmodifyer : MonoBehaviour
{
    public GameObject tool;
    public GameObject workpiece;
   // private float cuttingDepth = 0.001f; // Depth of each cut

    private Mesh workpieceMesh;
    private Vector3[] originalVertices;
    private bool isCutting = false;

    void Start()
    {
        // Ensure the workpiece has a mesh
        workpieceMesh = workpiece.GetComponent<MeshFilter>().mesh;

        // Store the original vertices of the workpiece
        originalVertices = workpieceMesh.vertices.Clone() as Vector3[];
    }

    void Update()
    {
        // Check for user input to start cutting
        Debug.Log("isCutting is "+isCutting);
        if (isCutting)
        {
            
            // Simulate the cutting operation
            CutWorkpiece();
        }
    }

    void CutWorkpiece()
    {
        // Find the local position of the tool relative to the workpiece
        Vector3 toolLocalPosition = workpiece.transform.InverseTransformPoint(tool.transform.position);

        // Modify the mesh based on the tool's position
        ModifyMesh(toolLocalPosition);


        // Check if the cutting is complete
        //if (tool.transform.position.z >= workpiece.transform.position.z - workpiece.transform.localScale.z / 2)
        //{
        //    isCutting = false;
        //    ResetWorkpiece();
        //}
    }

    void ModifyMesh(Vector3 toolLocalPosition)
    {
        // Modify the mesh based on the tool's position (simplified example)
        // You may need to implement a more complex algorithm based on your requirements

        // Debug.Log(toolLocalPosition);
        for (int i = 0; i < workpieceMesh.vertices.Length; i++)
        {
            if (workpieceMesh.vertices[i].y < toolLocalPosition.y)
            {
                //Debug.Log("modifying");
                //workpieceMesh.vertices[i] = new Vector3(
                //    originalVertices[i].x,
                //    toolLocalPosition.y,
                //    originalVertices[i].z

                //);
                ReplaceVertex(i, new Vector3(
                                originalVertices[i].x,
                               toolLocalPosition.y,
                               originalVertices[i].z
                           ));
               
                Debug.Log(toolLocalPosition.y);
                Debug.Log(originalVertices[i].y);
                //Debug.Log("they are " + (workpieceMesh.vertices[i] == originalVertices[i]));
                //Debug.Log("They are " + originalVertices.SequenceEqual(workpieceMesh.vertices));

            }
        }

        // Update the mesh
        workpieceMesh.RecalculateNormals();
        workpieceMesh.RecalculateBounds();
    }
    //void ModifyMesh(Vector3 toolLocalPosition)
    //{
    //    // Ensure the toolLocalPosition is along the x-axis (feed motion)
    //    toolLocalPosition.y = 0f;  // Assuming y-axis is the axis of the cylinder

    //    for (int i = 0; i < workpieceMesh.vertices.Length; i++)
    //    {
    //        // Check if the vertex is below the tool's y position and outside the cutting radius
    //        if (workpieceMesh.vertices[i].y < toolLocalPosition.y &&
    //            Vector3.Distance(new Vector3(workpieceMesh.vertices[i].x, 0f, workpieceMesh.vertices[i].z), Vector3.zero) > toolLocalPosition.x)
    //        {
    //            // Modify only the vertices that meet the cutting conditions
    //            workpieceMesh.vertices[i] = new Vector3(
    //                0,
    //                toolLocalPosition.y,
    //                0
    //            );
    //        }
    //    }

    //    // Update the mesh
    //    workpieceMesh.RecalculateNormals();
    //    workpieceMesh.RecalculateBounds();
    //}
    void ReplaceVertex(int vertexIndex, Vector3 newVertexPosition)
    {
        // Check if the provided index is valid
        if (vertexIndex >= 0 && vertexIndex < workpieceMesh.vertices.Length)
        {
            // Create a list to store the modified vertices
            List<Vector3> modifiedVertices = new List<Vector3>(workpieceMesh.vertices);

            // Replace the existing vertex with the new one at the specified index
            modifiedVertices[vertexIndex] = newVertexPosition;

            // Create a new mesh with the modified vertices
            Mesh newMesh = new Mesh();
            newMesh.vertices = modifiedVertices.ToArray();
            newMesh.triangles = workpieceMesh.triangles;

            // Assign the new mesh to the workpiece
            workpieceMesh = newMesh;

            // Update the mesh
            workpieceMesh.RecalculateNormals();
            workpieceMesh.RecalculateBounds();
        }
        else
        {
            Debug.LogError("Invalid vertex index provided.");
        }
    }

    void ResetWorkpiece()
    {
        // Reset the workpiece mesh to its original state
        workpieceMesh.vertices = originalVertices;
        workpieceMesh.RecalculateNormals();
        workpieceMesh.RecalculateBounds();
    }
    public void SetIsCutting(bool value)
    {
        isCutting = value;
    }

}
