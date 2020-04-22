using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] sounds;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        int randoSound = Random.Range(0, sounds.Length);
        audioSource.clip = sounds[randoSound];
        audioSource.Play();
    }
}
