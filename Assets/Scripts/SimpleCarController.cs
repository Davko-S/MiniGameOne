using UnityEngine;
using System.Collections;
using System.Collections.Generic;
    
public class SimpleCarController : MonoBehaviour {
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    public Rigidbody rb;
    public Vector3 centreOfMass;
    public float brakeForce = 1;

    void Start()
    {
        // Revealing the centre of mass to be able to lower it for better control
        rb = GetComponent<Rigidbody>();
        centreOfMass = rb.centerOfMass;
    }

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0) {
            return;
        }
     
        Transform visualWheel = collider.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        
        // The visual aspect of wheels was rotated 180 using wheel collider tutorial - this line solves the problem: 
        rotation = rotation * Quaternion.Euler(new Vector3(0, 180, 0)); 
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }        
    
    public void FixedUpdate()
    {
        // Using drag parameter to brake the player's truck
        rb.drag = Input.GetAxis("Left Bumper") * brakeForce; // Controller
        
        // Accelerate with Right Bumper on XBox controller
        float motor = maxMotorTorque * Input.GetAxis("Right Bumper"); // Controller
        
        //float motor = maxMotorTorque * Input.GetAxis("Vertical"); // Keyboard
        
        if (rb.drag >= 3) {
            motor = maxMotorTorque * -Input.GetAxis("Left Bumper"); // Controller
        }
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
            
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }
}
    
[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}
