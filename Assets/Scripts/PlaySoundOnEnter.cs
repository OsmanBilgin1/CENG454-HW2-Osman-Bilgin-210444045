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
        source.playOnAwake = false;
    }

    void OnTriggerEnter(Collider other)
    {   
        if (!other.CompareTag("Player"))
            return;
        
        // voice is triggered only entrance of the danger zone
        Vector3 localPos = transform.InverseTransformPoint(other.transform.position);
        if (localPos.z > 0)
        {
            source.Play();
        }

    }

    void OnTriggerExit(Collider other)
    {
        // source.Stop();
    }
}