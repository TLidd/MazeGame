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
    public float jumpVelocity;
    public float gravity;
    public float acceleration;


    //HORIZONTAL MOVEMENT
    public float xVelocity;
    public float yVelocity;
    public Vector3 xVector;
    public Vector3 yVector;
    public float speedModifier;
    public float maxSpeed;

    public bool isGrounded;

    public Rigidbody myRB;
    bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        InitializeGravity();
        InitializeVelocity();

        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump = true;
        }
       
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            Jump();
            jump = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            speedModifier = 10f;
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        speedModifier = 5f;
        isGrounded = false;
    }


    void HorizontalMovement()
    {
        myRB.velocity = new Vector3(-Input.GetAxis("Horizontal") * speedModifier, myRB.velocity.y, -Input.GetAxis("Vertical") * speedModifier);
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
        jumpVelocity = Mathf.Abs(gravity * timeToReachApex);
    }

    void Jump()
    {
        myRB.velocity = new Vector3(myRB.velocity.x, jumpVelocity, myRB.velocity.y);
    }

}
