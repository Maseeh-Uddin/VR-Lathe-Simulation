using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPostControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) { transform.Translate(0, 0, 0.005f); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(0, 0, -0.005f); }
    }
}
