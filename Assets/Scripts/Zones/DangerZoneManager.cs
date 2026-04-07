// DangerZoneManager.cs 
// CENG 454 - HW2 Midterm: Sky-High Prototype II 
// Author: Osman Bilgin | Student ID: 210444045

using TMPro;
using UnityEngine;

public class DangerZoneManager : MonoBehaviour
{
    [SerializeField] private TMP_Text warningMyText;
    [SerializeField] private string enterMessage = "Entered dangerous zone!";
    [SerializeField] private string exitMessage = "";
    [SerializeField] private CanvasGroup canvas;
    [SerializeField] private Transform jet;
    [SerializeField] private GameObject dangerobject;

    private bool areyouinside = false;
    private float timer = 0f;

    void Update()
    {
        if (areyouinside)
        {
            timer += Time.deltaTime;
            if (timer > 5.0f)
            {
                MissileLauncher launcher = dangerobject.GetComponent<MissileLauncher>();
                if (launcher != null)
                {
                    launcher.Launch(jet);

                }
                
                areyouinside = false;
                timer = 0f;
            }

        }
    } 

    void OnTriggerEnter(Collider other)
    {   
        if (!other.CompareTag("Player"))
            return;
        
        
        if (warningMyText != null)
        {
            warningMyText.text = enterMessage;
            areyouinside = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        
        if (warningMyText != null)
        {
            warningMyText.text = exitMessage;
            areyouinside = false;
        }
    }
    

}
