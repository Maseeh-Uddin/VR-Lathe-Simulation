using UnityEngine;

public class IntersectionFinder : MonoBehaviour
{
    private bool meshesIntersecting = false;

    void Update()
    {
        // Assuming this script is attached to one of the GameObjects
        GameObject otherObject = GameObject.Find("Lathe Machine - tool-1"); // Replace with the actual GameObject name

        if (otherObject != null)
        {
            // Get the MeshColliders of both GameObjects
            MeshCollider meshCollider1 = GetComponent<MeshCollider>();
            MeshCollider meshCollider2 = otherObject.GetComponent<MeshCollider>();

            if (meshCollider1 != null && meshCollider2 != null)
            {
                // Check for overlapping colliders
                Vector3 direction;
                float distance;
                meshesIntersecting = Physics.ComputePenetration(
                    meshCollider1, meshCollider1.transform.position, meshCollider1.transform.rotation,
                    meshCollider2, meshCollider2.transform.position, meshCollider2.transform.rotation,
                    out direction, out distance);

                if (meshesIntersecting)
                {
                    // Meshes are intersecting, set the cutting flag to true
                    // You can also perform additional actions or checks here
                    SetCuttingFlag(true);
                }
                else
                {
                    // Meshes are not intersecting, set the cutting flag to false
                    SetCuttingFlag(false);
                }
            }
        }
    }

    // Function to set the cutting flag in the meshmodifyer script
    void SetCuttingFlag(bool value)
    {
        meshmodifyer latheMachineScript = GetComponent<meshmodifyer>();
        if (latheMachineScript != null)
        {
            latheMachineScript.SetIsCutting(value);
        }
    }
}
