using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterBehaviour : MonoBehaviour
{
    public float BoostSpeed;
    public float ChargeTime;

    public float BoostTime;

    private bool isActive;

    public void Boost()
    {
        if (!isActive)
        {
            GameManager.Player.DisablePlayer();
            GameManager.Player.CurrentPlayer.transform.position = transform.position;
            GameManager.Player.CurrentPlayer.transform.localEulerAngles = Vector3.zero;

            StartCoroutine(BoostCharging());

            isActive = true;
        }
    }

    void BoostPlayer()
    {
        GameManager.Player.CurrentPlayer.myRigid.velocity = transform.TransformDirection(Vector3.forward) * BoostSpeed;
        StartCoroutine(GameManager.Player.WaitForBoostEnd(BoostTime));
    }

    IEnumerator BoostCharging()
    {
        yield return new WaitForSeconds(ChargeTime);
        BoostPlayer();
        yield return new WaitForSeconds(0.5f);
        isActive = false;
    }
}
