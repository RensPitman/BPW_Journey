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
        //CurrentCamera.Target = player.transform;

        CurrentPlayer = player.GetComponent<PlayerController>();
    }

    public void OnPlayerDeath()
    {
        // Hide player (Death)
        CurrentPlayer.AllowControl = false;
        CurrentPlayer.gameObject.SetActive(false);
        CurrentPlayer.transform.eulerAngles = Vector3.zero;
        CurrentPlayer.myRigid.velocity = Vector3.zero;
        // Small delay before reset.
        StartCoroutine(WaitForRespawn());
        
    }

    IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(0.5f);
        // Destroy all enemies in zone.
        GameManager.Gameplay.CurrentZone.DestroyAllEnemies();
        // Move player to center zone.
        CurrentPlayer.transform.position = new Vector3(GameManager.Gameplay.CurrentZone.transform.position.x, CurrentPlayer.transform.position.y, GameManager.Gameplay.CurrentZone.transform.position.z);
        // Show player (Respawn)
        CurrentPlayer.AllowControl = true;
        CurrentPlayer.gameObject.SetActive(true);
        // respawn enemies.
        GameManager.Gameplay.CurrentZone.SpawnEnemies();
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
