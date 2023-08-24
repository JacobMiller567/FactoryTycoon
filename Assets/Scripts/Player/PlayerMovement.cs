using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //[SerializeField] private Transform groundCheck;
   // [SerializeField] private LayerMask ground;
   // [SerializeField] private Animator animator;
    private CharacterController controller;
    private Vector3 velocity;
    [SerializeField] private float speed = 6.5f;
  //  private float groundDistance = 0.1f; // .4
   // [SerializeField] private float jumpHeight = 2.5f;
    [SerializeField] private float sprint = 10f;
    private float gravity = -9.81f;  // default gravity
    private float holdSpeed;

    private bool isRunning;
    private bool onGround;
  //  Transform LeftHand;
   // Transform RightHand;
    //private bool hasStamina = true;

    public Camera ArcadeCamera;

   
   

    void Start()
    {
        ArcadeCamera.enabled = false;
        controller = gameObject.GetComponent<CharacterController>();
        holdSpeed = speed; 
    }

    void Update()
    {
       onGround = controller.isGrounded;
       if (onGround && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        
        Vector3 move = (transform.right * horizontal + transform.forward * vertical).normalized;
        controller.Move(move * speed * Time.deltaTime);




        if (Input.GetKey(KeyCode.LeftShift)) // While player holds shift player can sprint
        {
            if(!isRunning) // if player is not already running
            {
              // StartCoroutine(Stamina());
                speed = sprint; // set speed to sprint value
                isRunning = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) // When player releases shift
        {
            speed = holdSpeed; // set speed back to normal
            isRunning = false;
            // StartCoroutine(Stamina());
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        
    }


}

