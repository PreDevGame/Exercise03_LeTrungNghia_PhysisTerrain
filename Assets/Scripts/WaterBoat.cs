using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Float))]
public class WaterBoat : MonoBehaviour
{
    public Transform Boat;
    public float SteerPower = 10f;
    public float Power = 2f;
    public float MaxSpeed = 100f;
    public float Drag = 0.5f;

    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;
    protected Camera Camera;
    protected Vector3 CameraVelocity;


    public void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        StartRotation = Boat.localRotation;
        Camera = Camera.main;
    }

    public void FixedUpdate()
    {
        var forceDirection = transform.forward;
        var steer = 0;

        if (Input.GetKey(KeyCode.A))
            steer = 1;
        if (Input.GetKey(KeyCode.D))
            steer = -1;

        Rigidbody.AddTorque((steer * -transform.up * Drag * SteerPower)/ 10f, ForceMode.Force);

        var forward = Vector3.Scale(new Vector3(1,0,1), transform.forward);
        var targetVel = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            RigidBodyPhysics.AddForceToReadVelocity(Rigidbody, forward * MaxSpeed * Drag, Power);
        if (Input.GetKey(KeyCode.S))
            RigidBodyPhysics.AddForceToReadVelocity(Rigidbody, forward * -MaxSpeed * Drag, Power);


        var movingForward = Vector3.Cross(transform.forward, Rigidbody.velocity).y < 0;


        Rigidbody.velocity = Quaternion.AngleAxis(Vector3.SignedAngle(Rigidbody.velocity, (movingForward ? 1f : 0f) * transform.forward, Vector3.up) * Drag, Vector3.up) * Rigidbody.velocity;

        Camera.transform.LookAt(transform.position + transform.forward * 6f + transform.up * 2f);
        Camera.transform.position = Vector3.SmoothDamp(Camera.transform.position, transform.position + transform.forward * -8f + transform.up * 2f, ref CameraVelocity, 0.05f);

    }

}