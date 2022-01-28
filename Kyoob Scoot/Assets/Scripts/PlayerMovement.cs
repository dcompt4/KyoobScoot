
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Reference to rigid body called body
    public Rigidbody body;
    public float jumpSpeed = 500.0f;
    public float spinSpeed = 200.0f;
    public float turnSpeed = 250.0f;
    public float gameSpeed = 250.0f;
    public float cooldown = 1f;
    private float lastJump;


    // Start is called before the first frame update
    void Start()
    {
        body.position = new Vector3(0f, 0.5f, 0f);
        body.velocity = new Vector3(0 , 0, gameSpeed);
    }

    // Update is called once per frame
    void Update() 
    {

    }

    void FixedUpdate() 
    {   
        
        if(Input.GetKey("d"))
        {
            body.AddForce(turnSpeed * Time.deltaTime, 0, 0);
            //Debug.Log(body.position.z);
        }

        if(Input.GetKey("a"))
        {
            body.AddForce(-turnSpeed * Time.deltaTime, 0, 0);
            //Debug.Log(body.position.z);
        }

        if (lastJump > cooldown) // only check for space bar if we last fired longer than the cooldown time
        {
            if (Input.GetKey(KeyCode.Space))
            {
                body.AddForce(0, jumpSpeed, 0);
                body.AddTorque(spinSpeed, 0, 0);
                // instantiate jump
                // set jump to initial position
                lastJump = 0; // reset last time fired
            }
        }
        else
        {
            lastJump += Time.deltaTime;
        }



        if(body.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }
}
