// DangerZoneManager.cs 
// CENG 454 - HW2 Midterm: Sky-High Prototype II 
// Author: Osman Bilgin | Student ID: 210444045

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
    private GameObject ActiveMissile;

    private bool hasEnteredDangerZone = false;
    private bool hasExitedDangerZone = false;
    private bool missionFailed = false;
    private bool missionCompleted = false;

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
            hasEnteredDangerZone = true;
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
            timer = 0f;
            if (!missionFailed)
            {
               hasExitedDangerZone = true;  
            }

            if (ActiveMissile != null)
            {
                Destroy(ActiveMissile);
            }
            
        }
    }
    
    public void getMissile(GameObject Missile)
    {
    ActiveMissile = Missile;
    }

    public void SetMissionFailed()
    {
        missionFailed = true;
    }

    public bool CanCompleteMission()
    {
        Debug.Log($"STATE => Entered:{hasEnteredDangerZone} Exited:{hasExitedDangerZone} Failed:{missionFailed} Completed:{missionCompleted}");
        return hasEnteredDangerZone && hasExitedDangerZone && !missionFailed && !missionCompleted;
    }
    public void StartSuccessProcess(TMP_Text successText, string message)
    {
        if (missionCompleted)
            return;

        missionCompleted = true;

        if (successText != null)
        {
            successText.text = message;
        }

        StartCoroutine(WaitAndRestart());
    }

    public void StartRestartProcess()
    {
        StartCoroutine(WaitAndRestart());
    }

    private IEnumerator WaitAndRestart()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
