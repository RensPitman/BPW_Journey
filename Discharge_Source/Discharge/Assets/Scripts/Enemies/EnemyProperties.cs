using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyProperties : MonoBehaviour
{
    public GameObject BurstPrefab;

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
                GameObject obj = Instantiate(BurstPrefab, transform.position, Quaternion.identity);

                CameraShaker.Instance.ShakeOnce(2, 15, 0, 1);
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
