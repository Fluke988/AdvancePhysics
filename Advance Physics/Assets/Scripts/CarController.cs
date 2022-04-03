using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool attachedToMotor;
    public bool attachedToSteering;
}

public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    void Start()
    {

    }
    void ApplyLocalPositionToVisuals(WheelCollider wheelColl)
    {
        if (wheelColl.transform.childCount == 0)
        {
            return;
        }
        Transform visualWheel = wheelColl.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;
        wheelColl.GetWorldPose(out position, out rotation);
        visualWheel.transform.position = position;
        visualWheel.rotation = rotation;
    }
    void FixedUpdate()
    {
        float motorTorque = maxMotorTorque * Input.GetAxis("Vertical");
        float steeringAngle = maxSteeringAngle * Input.GetAxis("Horizontal");
        foreach (AxleInfo item in axleInfos)
        {
            if (item.attachedToSteering)
            {
                item.leftWheel.steerAngle = steeringAngle;
                item.rightWheel.steerAngle = steeringAngle;
            }
            if (item.attachedToMotor)
            {
                item.leftWheel.motorTorque = motorTorque;
                item.rightWheel.motorTorque = motorTorque;
            }
            ApplyLocalPositionToVisuals(item.leftWheel);
            ApplyLocalPositionToVisuals(item.rightWheel);
        }
    }
}
