using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public bool AllowFollow;

    public Transform Target;

    public float MovementSpeed;

    [Tooltip("X is min, Y is max")]
    public Vector2 xMinMax;
    [Tooltip("X is min, Y is max")]
    public Vector2 zMinMax;

    private void Update()
    {
        if (AllowFollow)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Target.position.x, 0, Target.position.z), MovementSpeed * Time.deltaTime);

            Vector3 clammedPos = transform.position;

            clammedPos.x = Mathf.Clamp(clammedPos.x, xMinMax.x, xMinMax.y);
            clammedPos.z = Mathf.Clamp(clammedPos.z, zMinMax.x, zMinMax.y);

            transform.position = clammedPos;
        }
    }
}
