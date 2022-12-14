using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove;
    public bool usingKeyItem;
    public float moveSpeed;
    public float moveSpeedSlowed;
    public float moveSpeedVerySlow;
    public float moveSpeedShitMyPantSlow;
    public float currentSpeed;
    private float multiplier = 10f;
    public bool inHeavySnow = false;
    public bool crouching = false;
    public bool inFearAura = false;
    public AudioSource walkingSound;
    float horizontal;
    float vertical;
    public Rigidbody rb;
    public GameObject vcamFollow;
    public GameObject vcamFollowCrouch;
    public CinemachineVirtualCamera cam;
    PlayerAttacked attacked;
    PlayerMotivation motiv;


    Vector3 moveDirection;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        rb.freezeRotation = true;
        attacked = this.GetComponentInParent<PlayerAttacked>();
        motiv = this.GetComponentInParent<PlayerMotivation>();

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x != 0)
        {
            if (!walkingSound.isPlaying)
            {
                walkingSound.Play();
            }
        }
        else walkingSound.Stop();

        if (motiv.currentMotivation <= 0)
        {
            canMove = false;
        }
        if (attacked.beingAttacked)
        {
            canMove = false;
            
            rb.velocity = Vector3.zero;
        }
        if (usingKeyItem)
        {
            canMove = false;
        }

        Movement();
        if (inHeavySnow || crouching || inFearAura)
        {
            currentSpeed = moveSpeedSlowed;
        }
        else currentSpeed = moveSpeed;
        if (inHeavySnow && crouching)
        {
            currentSpeed = moveSpeedVerySlow;
        }
        if (inHeavySnow && inFearAura)
        {
            currentSpeed = moveSpeedVerySlow;
        }
        if (crouching && inFearAura)
        {
            currentSpeed = moveSpeedVerySlow;
        }
        if (crouching && inFearAura && inHeavySnow)
        {
            currentSpeed = moveSpeedShitMyPantSlow;
        }

        if (attacked.beingAttacked)
        {
            cam.Follow = GameObject.Find("Monster").transform;
        }
        else cam.Follow = vcamFollow.transform;

        if (crouching)
        {
            cam.Follow = vcamFollowCrouch.transform;
        }
        else cam.Follow = vcamFollow.transform;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouching = true;
        }
        else crouching = false;
    }

    void Movement()
    {
        if (canMove)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            rb.drag = 6f;

            moveDirection = transform.forward * vertical + transform.right * horizontal;
            moveDirection.y = 0;
        }
        

    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.AddForce(moveDirection.normalized * currentSpeed * multiplier, ForceMode.Acceleration);

        }
        
    }
    


}
