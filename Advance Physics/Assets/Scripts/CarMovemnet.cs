using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovemnet : MonoBehaviour
{
    float horizantalInput;
    float verticalInput;
    float steeringAngle;
    float motorTorque;
    public WheelCollider leftFrontWheelW;
    public WheelCollider rightFrontWheelW;
    public WheelCollider leftRareWheelW;
    public WheelCollider rightRareWheelW;
    public Transform leftFrontWheelT;
    public Transform rightFrontWheelT;
    public Transform leftRareWheelT;
    public Transform rightRareWheelT;
    public float maxSteeringAngle;
    public float maxMotorTorque;

    void Start()
    {

    }
    void Update()
    {
        GetInput();
    }
    void FixedUpdate()
    {
        Steer();
        Accelerate();
        UpdateWheelPos();
    }

    void GetInput()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizantalInput = Input.GetAxis("Horizontal");
    }
    void Steer()
    {
        steeringAngle = maxSteeringAngle * horizantalInput;
        leftFrontWheelW.steerAngle = steeringAngle;
        rightFrontWheelW.steerAngle = steeringAngle;
    }
    void Accelerate()
    {
        motorTorque = maxMotorTorque * verticalInput;
        leftFrontWheelW.motorTorque = motorTorque /** verticalInput*/;
        rightFrontWheelW.motorTorque = motorTorque /** verticalInput*/;
    }
    void UpdateWheelPos()
    {
        UpdateWheelPos(leftFrontWheelW, leftFrontWheelT);
        UpdateWheelPos(rightFrontWheelW, rightFrontWheelT);
        UpdateWheelPos(leftRareWheelW, leftRareWheelT);
        UpdateWheelPos(rightRareWheelW, rightRareWheelT);
    }
    void UpdateWheelPos(WheelCollider wheelColl, Transform _transform)
    {
        Vector3 _position = _transform.position;
        Quaternion _rotation = _transform.rotation;
        wheelColl.GetWorldPose(out _position, out _rotation);
        _transform.position = _position;
        _transform.rotation = _rotation;
    }
}
