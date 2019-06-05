using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    public List<GameObject> ChargeRings = new List<GameObject>();
    public List<ParticleSystem> Particles = new List<ParticleSystem>();

    private PlayerController controller;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(controller.isCharging)
        {
            if(!Particles[0].isPlaying)
                Particles[0].Play();
        }
        else
        {
            Particles[0].Stop();
        }

        if (controller.currentCharge > 0)
        {
            
        }

        if (controller.currentCharge == 500)
        {
            ChargeRings[0].SetActive(true);
            Particles[1].Play();
        }

        if (controller.currentCharge == 1000)
        {
            ChargeRings[1].SetActive(true);

            Particles[1].Play();
        }

        if(controller.currentCharge == 0)
        {
            ChargeRings[0].SetActive(false);
            ChargeRings[1].SetActive(false);
        }

    }
}
