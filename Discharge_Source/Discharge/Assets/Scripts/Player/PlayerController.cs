using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float ChargeSpeed;
    public float MaxCharge;

    public List<float> MovementSpeed = new List<float>();
    private float currentMovementSpeed;

    [HideInInspector]
    public bool isCharging;

    //[HideInInspector]
    public float currentCharge;

    private Rigidbody myRigid;

    private void Start()
    {
        myRigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (currentCharge > 0)
        {
            currentMovementSpeed = MovementSpeed[0];
        }

        if (currentCharge > 500)
        {
            currentMovementSpeed = MovementSpeed[1];
        }

        if (currentCharge == 1000)
        {
            

            currentCharge = 1001;
        }

        if(currentCharge == 1001)
            currentMovementSpeed = MovementSpeed[2];

        if (Input.GetMouseButtonDown(0))
            isCharging = true;

        if (Input.GetMouseButtonUp(0))
            Discharge();

        if(isCharging)
        {
            LookAtMouse();
            Charge();

            myRigid.velocity *= 0.95f;
        }
    }

    void Discharge()
    {
        isCharging = false;
        currentCharge = 0;

        //myRigid.AddForce(transform.TransformDirection(Vector3.forward) * ChargeSpeed, ForceMode.Impulse);

        myRigid.velocity = transform.TransformDirection(Vector3.forward) * currentMovementSpeed;
    }

    void Charge()
    {
        if (currentCharge <= MaxCharge)
        {
            if (currentCharge < MaxCharge)
                currentCharge += ChargeSpeed;
            else
                currentCharge = MaxCharge;
        }
    }

    void LookAtMouse()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
