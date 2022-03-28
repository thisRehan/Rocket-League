using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float steerAngle = 30;
    private float motorTorque = 1000;
    private float brakeForce = 3000;
    [SerializeField] private WheelCollider Front_LeftWheel_Collider;
    [SerializeField] private WheelCollider Front_RighttWheel_Collider;
    [SerializeField] private WheelCollider Back_LeftWheel_Collider;
    [SerializeField] private WheelCollider Back_RightWheel_Collider;
    [SerializeField] private Transform Front_LeftWheel_Transform;
    [SerializeField] private Transform Front_RightWheel_Transform;
    [SerializeField] private Transform Back_LeftWheel_Transform;
    [SerializeField] private Transform Back_RightWheel_Transform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        SteerAngle();
        Movement();
        UpdateWheelPosition();
        ApplyBreaking();
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    private void SteerAngle()
    {
        Front_LeftWheel_Collider.steerAngle = steerAngle * horizontalInput;
        Front_RighttWheel_Collider.steerAngle = steerAngle * horizontalInput;
    }
    private void Movement()
    {
        Front_LeftWheel_Collider.motorTorque = motorTorque * verticalInput ;
        Front_RighttWheel_Collider.motorTorque = motorTorque * verticalInput ;
        Back_LeftWheel_Collider.motorTorque = motorTorque * verticalInput ;
        Back_RightWheel_Collider.motorTorque = motorTorque * verticalInput ;
    }
    private void ApplyBreaking()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Front_LeftWheel_Collider.brakeTorque = brakeForce;
            Front_RighttWheel_Collider.brakeTorque = brakeForce;
            Back_LeftWheel_Collider.brakeTorque = brakeForce;
            Back_RightWheel_Collider.brakeTorque = brakeForce;
            Front_LeftWheel_Collider.motorTorque = 0 ;
            Front_RighttWheel_Collider.motorTorque = 0 ;
            Back_LeftWheel_Collider.motorTorque = 0 ;
            Back_RightWheel_Collider.motorTorque = 0 ;
        }
        else
        {
            Front_LeftWheel_Collider.brakeTorque = 0;
            Front_RighttWheel_Collider.brakeTorque = 0;
            Back_LeftWheel_Collider.brakeTorque = 0;
            Back_RightWheel_Collider.brakeTorque = 0;
        }
    }
    private void UpdateWheelPosition()
    {
        UpdateSingleWheelPosition(Front_LeftWheel_Collider, Front_LeftWheel_Transform);
        UpdateSingleWheelPosition(Front_RighttWheel_Collider, Front_RightWheel_Transform);
        UpdateSingleWheelPosition(Back_LeftWheel_Collider, Back_LeftWheel_Transform);
        UpdateSingleWheelPosition(Back_RightWheel_Collider, Back_RightWheel_Transform);
    }
    private void UpdateSingleWheelPosition(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
