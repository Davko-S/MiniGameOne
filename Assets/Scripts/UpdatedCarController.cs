using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedCarController : MonoBehaviour
{
    private float horizontalInput;
    private float forwardInputXbox;
    private float backInputXbox;
    private float verticalInput;
    private float steeringAngle;

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;

    public float maxSteerAngle = 30;
    public float motorForce = 200;
    public float brakeForce = 200;
    public float gravityModifier = 1;

    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        forwardInputXbox = Input.GetAxis("Right Bumper");
        backInputXbox = Input.GetAxis("Left Bumper");
    }
    
    private void Steer()
    {
        steeringAngle = maxSteerAngle * horizontalInput;
        frontDriverW.steerAngle = steeringAngle;
        frontPassengerW.steerAngle = steeringAngle;
    }

    private void Accelerate()
    {
        
        if (verticalInput < 0)
        {
            frontDriverW.motorTorque = verticalInput * brakeForce;
            frontPassengerW.motorTorque = verticalInput * brakeForce;
        } else
        {
            frontDriverW.motorTorque = verticalInput * motorForce;
            frontPassengerW.motorTorque = verticalInput * motorForce;
        }

        
        //frontDriverW.motorTorque = forwardInputXbox * motorForce;
        //frontPassengerW.motorTorque = forwardInputXbox * motorForce;
    }

    private void Brake()
    {
        frontDriverW.brakeTorque = backInputXbox * brakeForce;
        frontPassengerW.brakeTorque = backInputXbox * brakeForce;
        frontDriverW.brakeTorque = backInputXbox * brakeForce;
        frontPassengerW.brakeTorque = backInputXbox * brakeForce;
    }


    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    private void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        Vector3 pos;
        Quaternion quat;

        collider.GetWorldPose(out pos, out quat);

        transform.position = pos;
        transform.rotation = quat * Quaternion.Euler(new Vector3(0, 180, 0));

    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        Brake();
        UpdateWheelPoses();
    }

    private void Start()
    {
        Physics.gravity *= gravityModifier;
    }

}
