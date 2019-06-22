using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndBehaviour : MonoBehaviour
{
    public TriggerBehaviour MyTrigger;
    public GameObject GateObj;

    public void OpenGate()
    {
        MyTrigger.enabled = true;
        GateObj.SetActive(true);
    }
}
