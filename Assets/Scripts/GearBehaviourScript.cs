using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBehaviourScript : MonoBehaviour
{
    public float rotationSpeed = 2.0f;
    public bool isSpinning = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isSpinning) 
        { 
            float yRotation = gameObject.transform.rotation.y;
            gameObject.transform.Rotate(0.0f, rotationSpeed, 0.0f, Space.Self);
        }
    }
}
