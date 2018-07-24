using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleFaucet : MonoBehaviour
{
    public bool fuacetOn = false;


	void StartWater ()
    {
        if (this.fuacetOn)
        {
            this.GetComponent<ParticleSystem>().Play();
        }
        else
        {

            this.GetComponent<ParticleSystem>().Pause();
            this.GetComponent<ParticleSystem>().Clear();

        }

    }

    void Update ()
    {
        StartWater();
	}
}
