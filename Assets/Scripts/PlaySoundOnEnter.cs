// PlaySoundEnter.cs 
// CENG 454 - HW2 Midterm: Sky-High Prototype II 
// Author: Osman Bilgin | Student ID: 210444045

using UnityEngine;

public class PlaySoundOnEnter : MonoBehaviour
{
    AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            source.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        // source.Stop();
    }
}