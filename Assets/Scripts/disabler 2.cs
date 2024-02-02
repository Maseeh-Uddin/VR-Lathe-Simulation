using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disabler2 : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode disableKey = KeyCode.LeftShift;
    public MonoBehaviour targetScript; // Assign the script you want to disable in the Inspector

    // Update is called once per frame
    void Update()
    {
        // Check if the specified key is pressed
        if (Input.GetKeyDown(disableKey))
        {
            // Toggle the enabled state of the target script
            if (targetScript != null)
            {
                targetScript.enabled = !targetScript.enabled;
            }
        }
    }
}
