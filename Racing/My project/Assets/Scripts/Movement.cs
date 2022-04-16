using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 50;
    [SerializeField] float MaxSpeed = 15;
    [SerializeField] float Drag = 0.98f;
    [SerializeField] float SteerAngle = 20;
    [SerializeField] float Traction = 1;
    [SerializeField] Transform carPos;
    [SerializeField] FixedJoystick joystick;
   
    private Vector3 MoveForce;


    void Update()
    {
        MoveControl();
    }
    private void MoveControl()
    {
        MoveForce += carPos.forward * MoveSpeed * joystick.Vertical * Time.deltaTime;
        carPos.position += MoveForce * Time.deltaTime;

        float steerInput = joystick.Horizontal;
        carPos.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;
    }
}
