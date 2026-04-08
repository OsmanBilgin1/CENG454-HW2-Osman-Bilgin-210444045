// LandingZoneController.cs 
// CENG 454 - HW2 Midterm: Sky-High Prototype II 
// Author: Osman Bilgin | Student ID: 210444045

using UnityEngine;
using TMPro;

public class LandingZoneController : MonoBehaviour
{
    [SerializeField] private TMP_Text SuccessText;
    [SerializeField] private string successMessage = "Mission Completed!";

    void OnTriggerEnter(Collider other)
    {   
        if (!other.CompareTag("Player"))
            return;
        
        
        if (SuccessText != null)
        {
            SuccessText.text = successMessage;
    
        }

    }
}