using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerController CurrentPlayer;

    public CameraBehaviour CurrentCamera;

    public GameObject PlayerPrefab;

    private void Awake()
    {
        SpawnPlayer();
    }

    public void DisablePlayer()
    {
        CurrentPlayer.myRigid.velocity = Vector3.zero;
        CurrentPlayer.AllowControl = false;
        CurrentPlayer.isCharging = false;
        CurrentPlayer.isFullCharge = false;
        CurrentPlayer.isMoving = false;
        CurrentPlayer.currentCharge = 0;
    }

    public void EnablePlayerAfterBoost()
    {
        CurrentPlayer.doneBoosting = true;
    }

    public void SpawnPlayer()
    {
        GameObject player = (GameObject)Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity);

        // Set Camera Target.
        CurrentCamera.Target = player.transform;

        CurrentPlayer = player.GetComponent<PlayerController>();
    }

    public void PlayerIsCameraTarget()
    {
        CurrentCamera.Target = CurrentPlayer.transform;
    }

    public void SetCameraTarget(Transform target)
    {
        CurrentCamera.Target = target;
    }

    public IEnumerator WaitForBoostEnd(float time)
    {
        yield return new WaitForSeconds(time);
        EnablePlayerAfterBoost();
    }
}
