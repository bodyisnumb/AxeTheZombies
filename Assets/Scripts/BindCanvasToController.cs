using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindCanvasToController : MonoBehaviour
{
    public Transform leftController; // Assign your left controller in the Inspector

    void Update()
    {
        if (leftController != null)
        {
            // Set the position and rotation of the Canvas to match the left controller
            transform.position = leftController.position;
            transform.rotation = leftController.rotation;
        }
    }
}
