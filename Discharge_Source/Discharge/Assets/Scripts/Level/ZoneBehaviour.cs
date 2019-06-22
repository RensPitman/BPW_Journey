using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZoneBehaviour : MonoBehaviour
{
    public Vector3 Size;
    public Vector3 Offset;

    [HideInInspector]
    public bool isActive;
    public bool isFinish;

    public List<EnemySpawnPoint> AllSpawnPoints;
    public List<GameObject> AllEnemies;

    public UnityEvent OnZoneFinish;

    private void Update()
    {
        if (!isFinish)
        {
            AllEnemies = AllEnemies.Where(item => item != null).ToList();

            if (AllEnemies.Count == 0)
            {
                if (this == GameManager.Gameplay.CurrentZone)
                {
                    // Zone is clear
                    isActive = false;
                    isFinish = true;

                    if (OnZoneFinish != null)
                        OnZoneFinish.Invoke();
                }
            }
        }
    }

    public void SpawnEnemies()
    {
        for(int i = 0; i < AllSpawnPoints.Count; ++i)
        {
            AllSpawnPoints[i].SpawnEnemy();
        }
    }

    public void DestroyAllEnemies()
    {
        for(int i = 0; i < AllEnemies.Count; ++i)
        {
            Destroy(AllEnemies[i]);
        }

        AllEnemies = new List<GameObject>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + Offset, Size);
    }
}
