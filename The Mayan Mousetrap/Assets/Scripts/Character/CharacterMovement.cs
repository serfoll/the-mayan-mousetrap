using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{

    //Define moving states
    public enum MovingState { Walking, Jogging, Spriting, Crouching }

    //Variables
    public float moveSpeed = 8f;
    public float jumpForce = 10f;
    private float smoothSpeed;
    private float rotationSpeed = 10f;
    public float lengthToGround = 2.5f;
    public bool isGrounded;
    private bool inAir;

    //Components
    public Transform characterMesh;
    private Vector3 velocity;
    private Rigidbody rb;
    private MovingState movingState;
    public LayerMask groundLayer;

    //Delagate()
    public delegate void OnLandedDelagate();
    //Delegate event
    public event OnLandedDelagate onLanded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inAir = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), lengthToGround, groundLayer);
        
        //Draw Raycast downwards
        Vector3 downRay = transform.TransformDirection(Vector3.down) * lengthToGround;
        Debug.DrawRay(transform.position, downRay, Color.green);

        //Rotate character to face the Movement direction 
        if (velocity.magnitude > 0)
        {
            smoothSpeed = Mathf.Lerp(smoothSpeed, moveSpeed, Time.deltaTime);
            //characterMesh.rotation = Quaternion.LookRotation(velocity);
            characterMesh.rotation = Quaternion.Lerp(characterMesh.rotation,
                Quaternion.LookRotation(velocity), rotationSpeed * Time.deltaTime);
        }
        else
        {
            smoothSpeed = Mathf.Lerp(smoothSpeed, 0f, Time.deltaTime);
        }

        if (inAir)
        {
            if (isGrounded)
            {
                inAir = false;
                onLanded();
            }
        }
    }

    private void FixedUpdate()
    {
        if (velocity.magnitude > 0)
        {
            rb.velocity = new Vector3(velocity.normalized.x * smoothSpeed, rb.velocity.y, velocity.normalized.z * smoothSpeed);
        }

        else
            rb.velocity = new Vector3(velocity.normalized.x * smoothSpeed, rb.velocity.y, velocity.normalized.z * smoothSpeed);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            inAir = true;
        }
    }

    //Get and set velocity
    public Vector3 Velocity { get => rb.velocity; set => velocity = value; }

    public void SetMovingState(MovingState state)
    {
        movingState = state;
        switch (state)
        {
            case MovingState.Walking:
                {
                    moveSpeed = 7;
                    break;
                }
            case MovingState.Jogging:
                {
                    moveSpeed = 9;
                    break;
                }
            case MovingState.Spriting:
                {
                    moveSpeed = 14;
                    break;
                }
            case MovingState.Crouching:
                {
                    moveSpeed = 5;
                    break;
                }
        }
        //Debug.Log(state);
    }//end SetMovingState()

    public MovingState GetMovingState()
    {
        return movingState;
    } //end GetMovingState()
}