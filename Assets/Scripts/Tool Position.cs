using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPosition : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 tipLocalPosition;
    void Start()
    {
        // Assuming the tip is at the bottom of the tool
        tipLocalPosition = Vector3.down * (GetComponent<MeshFilter>().mesh.bounds.extents.y);
    }

    // Update is called once per frame
    void Update()
    {
        // Convert local position to world position
        Vector3 tipWorldPosition = transform.TransformPoint(tipLocalPosition);

        // Print or use the tip position
        //Debug.Log("Tip Position: " + tipWorldPosition);

    }
}
