using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Vector3 _velocity;
    Rigidbody myRigitBody;

    void Start()
    {
        myRigitBody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 velocity)
    {
        _velocity = velocity;
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    public void FixedUpdate()
    {
        myRigitBody.MovePosition(myRigitBody.position + _velocity * Time.fixedDeltaTime);
    }
}
