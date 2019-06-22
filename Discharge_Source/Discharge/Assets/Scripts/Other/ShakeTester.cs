using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ShakeTester : MonoBehaviour
{
    public float Magnitude;
    public float Roughness;
    public float FadeIn;
    public float FadeOut;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            CameraShaker.Instance.ShakeOnce(Magnitude, Roughness, FadeIn, FadeOut);
    }
}
