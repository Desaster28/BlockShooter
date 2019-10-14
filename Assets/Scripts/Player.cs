using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5;

    Camera viewCamera;
    PlayerController controller;
    GunController gunController;

    void Start()
    {
        viewCamera = Camera.main;
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
    }

    void Update()
    {
        //Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        //Look input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDiastance;

        if(groundPlane.Raycast(ray, out rayDiastance))
        {
            Vector3 point = ray.GetPoint(rayDiastance);
            controller.LookAt(point);
        }

        //Weapon input
        if (Input.GetMouseButton(0))
        {
            gunController.Shoot();
        }
    }
}
