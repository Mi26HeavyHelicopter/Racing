using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float speed;
    [SerializeField] float turnSpeed = 5.0f;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform carTransforme;
   
    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        //playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
       // rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, joystick.Vertical * speed);
        rigidbody.AddRelativeForce(Vector3.forward * speed * joystick.Vertical);
        rigidbody.AddRelativeForce(Vector3.right * speed * joystick.Horizontal);
        // carTransforme.Translate(Vector3.right * Time.deltaTime * turnSpeed * joystick.Horizontal);
        //  carTransforme.Rotate(Vector3.up, Time.deltaTime * turnSpeed * joystick.Horizontal);
    }
}
