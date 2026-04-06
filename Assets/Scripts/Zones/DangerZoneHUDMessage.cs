// DangerZoneHUDMessage.cs 
// CENG 454 - HW2 Midterm: Sky-High Prototype II 
// Author: Osman Bilgin | Student ID: 210444045

using TMPro;
using UnityEngine;

public class DangerZoneHUDMessage : MonoBehaviour
{
    [SerializeField] private TMP_Text warningMyText;
    [SerializeField] private string enterMessage = "Entered dangerous zone!";
    [SerializeField] private string exitMessage = "Zombie";

    private void Start()
    {
        if (warningMyText != null)
        {
            warningMyText.text = "";

        }
    }

    void OnTriggerEnter(Collider other)
    {   
        if (!other.CompareTag("Player"))
            return;
        
        
        if (warningMyText != null)
        {
            warningMyText.text = enterMessage;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        
        if (warningMyText != null)
        {
            warningMyText.text = exitMessage;
        }
    }
    

}
