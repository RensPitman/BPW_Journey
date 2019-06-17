using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent myAgent;

    private Transform myTarget;

    private void Start()
    {
        myTarget = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        myAgent.SetDestination(myTarget.position);
    }
}
