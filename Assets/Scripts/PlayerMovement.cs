using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform cameraTransform;
    private float multiplier = 10f;

    float horizontal;
    float vertical;
    public Rigidbody rb;
    

    Vector3 moveDirection;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked; 
        cameraTransform = Camera.main.transform;
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        rb.drag = 6f;

        moveDirection = transform.forward * vertical + transform.right * horizontal;

    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * multiplier, ForceMode.Acceleration);
    }



}
