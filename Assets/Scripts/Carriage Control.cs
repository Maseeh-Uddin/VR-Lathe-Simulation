using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriageControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)) { transform.Translate(0.005f, 0, 0); }
        if (Input.GetKey(KeyCode.A)) { transform.Translate(-0.0014f, 0, 0); }

    }
}
