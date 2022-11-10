using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveSpeedSlowed = 2f;
    private float currentSpeed;
    private float multiplier = 10f;
    private bool inHeavySnow = false;
    public bool crouching = false;
    float horizontal;
    float vertical;
    public Rigidbody rb;
    public GameObject vcamFollow;
    

    Vector3 moveDirection;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked; 
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (inHeavySnow)
        {
            currentSpeed = moveSpeedSlowed;
        }
        else currentSpeed = moveSpeed;

        if (crouching)
        {
            
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouching = true;
        }
        else crouching = false;
    }

    void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        rb.drag = 6f;

        moveDirection = transform.forward * vertical + transform.right * horizontal;
        moveDirection.y = 0;

    }
    private void FixedUpdate()
    {
        rb.AddForce(moveDirection.normalized * currentSpeed * multiplier, ForceMode.Acceleration);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == ("Snow"))
        {
            Debug.Log("slow");
            inHeavySnow = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == ("Snow"))
        {
            Debug.Log("not slowed");
            inHeavySnow = false;
        }
    }


}
