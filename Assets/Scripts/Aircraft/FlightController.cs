// FlightController.cs 
// CENG 454 – HW1: Sky-High Prototype 
// Author: Osman Bilgin | Student ID: 210444045
 
using UnityEngine; 
 
public class FlightController : MonoBehaviour 
{ 
    [SerializeField] private float pitchSpeed  = 45f;  // degrees/second 
    [SerializeField] private float yawSpeed    = 45f;  // degrees/second 
    [SerializeField] private float rollSpeed   = 45f;  // degrees/second 
    [SerializeField] private float thrustSpeed = 5f;   // units/second 
 
    private Rigidbody rb; 
 
    void Start() 
    { 
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
         
    }
    
    void Update() 
    { 
        HandleRotation(); 
        HandleThrust(); 
    } 
 
    private void HandleRotation() 
    {   
        // all the axis are defined at ınput manager
        float pitch = pitchSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float yaw = yawSpeed * Time.deltaTime * Input.GetAxis("Yaw");
        float roll = rollSpeed * Time.deltaTime * Input.GetAxis("Roll");

        transform.Rotate(pitch, yaw, roll, Space.Self);   
 
    } 
 
    private void HandleThrust() 
    { 
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime, Space.Self);
        }
         
    } 
}