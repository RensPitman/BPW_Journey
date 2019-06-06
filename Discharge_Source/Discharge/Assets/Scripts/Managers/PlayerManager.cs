using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerController CurrentPlayer;

    public GameObject PlayerPrefab;

    private void Awake()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        GameObject player = (GameObject)Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity);

        CurrentPlayer = player.GetComponent<PlayerController>();
    }
}
