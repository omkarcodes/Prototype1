using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Here are Variables
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] int wheelsOnGround;
    [SerializeField] private float horsePower = 0;
    private float turnSpeed = 25f;
    private float horizontalInput;
    private float forwardInput;

    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedoMeterText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;


    // Start is called before the first frame update 
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Getting Input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {

            // We'll move the vehicle forward
            //transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);

            transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f); //returns speed in Km/hr
            speedoMeterText.SetText("Speed: " + speed + " km/hr");

            rpm = (speed % 30) * 40;
            rpmText.SetText("RPM: " + rpm);

        }

    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if(wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
