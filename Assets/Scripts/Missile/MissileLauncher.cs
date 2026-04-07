// MissileLauncher.cs 
// CENG 454 - HW2 Midterm: Sky-High Prototype II 
// Author: Osman Bilgin | Student ID: 210444045

using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab; 
    [SerializeField] private Transform jet; 
    [SerializeField] private AudioSource launchAudioSource;

    private GameObject ActiveMissile;

    public GameObject Launch(Transform target)
    {
        // (Task 3-A): instantiate the missile at launchPoint
        ActiveMissile = Instantiate(missilePrefab, transform.position, transform.rotation);
        MissileHoming homingScript = ActiveMissile.GetComponent<MissileHoming>();

        if (homingScript != null)
        {
            homingScript.SetTarget(target);
        }

        // Task 3-B and Task 3-C
        if (launchAudioSource != null)
        {
            launchAudioSource.Play();
        }

        return ActiveMissile;
    }

    public void DestroyActiveMissile()
    {
        // TODO (Task 3-D): destroy the current missile safely if one exists
        if (ActiveMissile != null)
        {
            Destroy(ActiveMissile);
            ActiveMissile = null;  // Destroy() function cannot be trusted in c++
        }
    } 
}