using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    public float RotationSpeed;

    void Update()
    {
        transform.Rotate(Vector3.right * (RotationSpeed * Time.deltaTime));
    }
}
