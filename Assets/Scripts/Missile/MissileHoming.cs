// MissileHoming.cs 
// CENG 454 - HW2 Midterm: Sky-High Prototype II 
// Author: Osman Bilgin | Student ID: 210444045

using UnityEngine;
using TMPro;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private TMP_Text fail_message;

    private Transform target;
    private DangerZoneManager dangerZoneManager;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void SetTextReference(TMP_Text targetText)
    {
        fail_message = targetText;
    }

    public void SetDangerZoneManagerReference(DangerZoneManager managerRef)
    {
        dangerZoneManager = managerRef;
    }

    void Update()
    {
        // TODO (Task 3-F): rotate toward the target and move forward
        if (target == null)
        {
            Debug.LogWarning("Füze oluştu, hedef yok (Target is NULL!)");
            return;
        }

        moveToJet();
        rotateToJet();
    }

    void moveToJet()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
    }

    void rotateToJet()
    {
        Vector3 direction = target.position - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * turnSpeed);
            transform.rotation = rotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (fail_message != null)
        {
            fail_message.text = "Mission Failed!";
            SetTextOpacity(1.0f);
        }

        if (dangerZoneManager != null)
        {
            dangerZoneManager.StartRestartProcess();
        }

        Destroy(gameObject);
    }

    private void SetTextOpacity(float opacity)
{
    if (fail_message != null)
    {
        Color c = fail_message.color;
        c.a = opacity; 
        fail_message.color = c;
    }
}
}