using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleFaucet : MonoBehaviour
{
    public bool fuacetOn = false;
    private Quaternion handleHome;
    public Transform handlePos;

    private void Start()
    {
        this.handleHome = this.transform.rotation;
    }

    void StartWater ()
    {
        if (this.handlePos.rotation != this.handleHome)
        {
            this.GetComponent<ParticleSystem>().Play();
        }
        else if(this.handlePos.rotation == this.handleHome)
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
