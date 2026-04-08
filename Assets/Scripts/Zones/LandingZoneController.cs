// LandingZoneController.cs 
// CENG 454 - HW2 Midterm: Sky-High Prototype II 
// Author: Osman Bilgin | Student ID: 210444045

using UnityEngine;
using TMPro;

public class LandingZoneController : MonoBehaviour
{
    [SerializeField] private TMP_Text successText;
    [SerializeField] private string successMessage = "Mission Successful!";
    [SerializeField] private DangerZoneManager manager;
    private AudioSource successfulsound;

    void Start()
    {
        successfulsound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (manager == null)
            return;

        if (manager.CanCompleteMission())
        {
            manager.StartSuccessProcess(successText, successMessage);
            successfulsound.Play();
        }
    }
}