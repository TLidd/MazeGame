using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //I'm using physics formulas from this video:
    //https://www.youtube.com/watch?v=PlT44xr0iW0
    //VERTICAL MOVEMENT
    public float jumpHeight;
    public float timeToReachApex;
    private float jumpVelocity;
    private float gravity;
    private Vector3 jumpVector;

    //HORIZONTAL MOVEMENT
    private float xVelocity;
    private float yVelocity;
    public float speedModifier;
    private Vector3 movementVector;


    private bool isGrounded;
    public Transform groundChecker;
    public LayerMask groundLayer;
    public float groundCheckerRadius;

    public CharacterController controller;
    bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        InitializeGravity();
        InitializeVelocity();

        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        if(Physics.CheckSphere(groundChecker.transform.position, groundCheckerRadius, groundLayer))
        {
            isGrounded = true;
            jumpVector.y = -2;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && jumpVector.y < 0 )
        {
            jump = true;

        }
       
    }

    private void FixedUpdate()
    {
        jumpVector.y += gravity * Time.deltaTime;

        controller.Move( movementVector *speedModifier * Time.deltaTime);

        if (jump)
        {
            Jump();
            jump = false;
        }

        controller.Move(jumpVector * Time.deltaTime);
    }


    void HorizontalMovement()
    {
        xVelocity = Input.GetAxis("Horizontal");
        yVelocity = Input.GetAxis("Vertical");

        movementVector = transform.right * xVelocity + transform.forward * yVelocity;
    }

    //Use a variaiton of the second equation of motion to calculate
    //acceleration(gravity)
    void InitializeGravity()
    {
        gravity = -2 * (jumpHeight) / Mathf.Pow(timeToReachApex, 2);
        Physics.gravity = new Vector3(0, gravity, 0);
    }


    void InitializeVelocity()
    {
        //jumpVelocity = Mathf.Abs(gravity * timeToReachApex);
        jumpVelocity = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    void Jump()
    {
        jumpVector.y = jumpVelocity;
    }

}
