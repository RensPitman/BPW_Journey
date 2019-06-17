using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBehaviour : MonoBehaviour
{
    public bool OneShot;
    public Vector3 Size;
    public LayerMask PlayerMask;
    public UnityEvent OnTriggerActive;

    private bool hasBeenActive;

    private void Update()
    {
        if(!hasBeenActive)
            CheckTrigger();
    }

    void CheckTrigger()
    {
        Collider[] coll = Physics.OverlapBox(transform.position, Size, Quaternion.identity, PlayerMask);

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
        Gizmos.DrawWireCube(transform.position, Size);
    }
}
