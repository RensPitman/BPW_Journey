using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerStatus : MonoBehaviour
{
    public void OnDeath()
    {
        CameraShaker.Instance.ShakeOnce(2, 15, 0, 1);
        GameManager.Player.OnPlayerDeath();
    }
}
