using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public ZoneBehaviour CurrentZone;

    public List<ZoneBehaviour> AllZones;

    private void Start()
    {
        SetCurrentZone(0);
    }
    
    public void SetCurrentZone(int index)
    {
        if (index == 0)
        {
            CurrentZone = AllZones[index];
            CurrentZone.isActive = true;

            CurrentZone.SpawnEnemies();
        }

        if (CurrentZone.isFinish)
        {
            CurrentZone = AllZones[index];
            CurrentZone.isActive = true;
            CurrentZone.gameObject.GetComponent<TriggerBehaviour>().enabled = true;

            CurrentZone.SpawnEnemies();
        }
    }

    private void Update()
    {
        if (CurrentZone != null)
        {
            if (!CurrentZone.isActive)
                GameManager.Player.PlayerIsCameraTarget();
            else
                GameManager.Player.SetCameraTarget(CurrentZone.transform);                
        }
    }

}
