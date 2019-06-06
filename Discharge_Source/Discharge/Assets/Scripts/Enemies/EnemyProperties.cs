using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    [Header("Hitbox")]
    public float Radius;
    public LayerMask HitMask;

    private PlayerController hitPlayer;

    private void Update()
    {
        Hitbox();
    }

    void OnDeath()
    {
        if (hitPlayer.isFullCharge)
        {
            if (hitPlayer.isMoving)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            // DESTROY THE PLAYER
            hitPlayer.status.OnDeath();
        }
    }

    void Hitbox()
    {
        Collider[] coll = Physics.OverlapSphere(transform.position, Radius, HitMask);

        if(coll.Length > 0)
        {
            hitPlayer = coll[0].GetComponent<PlayerController>();
            OnDeath();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
