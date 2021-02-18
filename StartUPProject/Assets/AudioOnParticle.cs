using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ParticleSystem))]
public class AudioOnParticle : MonoBehaviour
{
    ParticleSystem particleSystem;
    AudioSource audioSource;

    [SerializeField]
    AudioClip shotSound;

    private int currentParticles=0;
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (particleSystem.particleCount < currentParticles)
        {
            //audioSource.PlayOneShot(shotSound);
            //Debug.Log("PlaySound");
        }

        currentParticles = particleSystem.particleCount;
    }
}
