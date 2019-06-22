using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public void SpawnEnemy()
    {
        GameObject obj = (GameObject)Instantiate(EnemyPrefab, transform.position, Quaternion.identity);

        obj.transform.parent = transform;

        GameManager.Gameplay.CurrentZone.AllEnemies.Add(obj);
    }
}
