using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBehaviour : MonoBehaviour
{
    public bool OneShot;
    public Vector3 Size;
    public Vector3 Offset;
    public LayerMask PlayerMask;
    public UnityEvent OnTriggerActive;

    private bool hasBeenActive;

    private void Update()
    {
        if (GameManager.Gameplay.CurrentZone.isFinish)
        {
            if (!hasBeenActive)
                CheckTrigger();
        }
    }

    void CheckTrigger()
    {
        Collider[] coll = Physics.OverlapBox(transform.position + Offset, new Vector3(Size.x / 2, Size.y / 2, Size.z / 2), Quaternion.identity, PlayerMask);

        if(coll.Length > 0)
        {
            OnTriggerActive.Invoke();

            if (OneShot)
                hasBeenActive = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + Offset, Size);
    }
}
