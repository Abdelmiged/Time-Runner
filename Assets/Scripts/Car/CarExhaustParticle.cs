using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarExhaustParticle : MonoBehaviour
{
    ParticleSystem exhaustParticles;
    // Start is called before the first frame update
    void Start()
    {
        exhaustParticles = GetComponent<ParticleSystem>();
        StartParticles();
    }

    // Update is called once per frame
    void Update()
    {
        EmitParticles();
    }

    private void EmitParticles()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            StartParticles();
            IncreaseParticles();
        }
        else
        {
            DecreaseParticles();
        }
    }

    private void StartParticles()
    {
        if(exhaustParticles.isPlaying == false) 
            exhaustParticles.Play();
    }

    private void IncreaseParticles()
    {
        var emission = exhaustParticles.emission;
        emission.rateOverTime = 30;
    }

    private void DecreaseParticles()
    {
        var emission = exhaustParticles.emission;
        emission.rateOverTime = 10;
    }
}
