using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Here are Variables
    private float speed = 30f;
    private float turnSpeed = 25f;
    private float horizontalInput;
    private float forwardInput;


    // Start is called before the first frame update 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Getting Input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        

        // We'll move the vehicle forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);
        
        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);
    }
}
