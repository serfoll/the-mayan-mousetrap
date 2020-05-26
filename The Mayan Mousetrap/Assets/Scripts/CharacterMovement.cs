using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    //Define moving states
    public enum MovingState { Walking, Jogging, Spriting, Crouching }
    //Variables
    public float moveSpeed = 8f;
    float smoothSpeed;
    //Components
    public Transform characterMesh;
    Vector3 velocity;
    Rigidbody rb;
    MovingState movingState;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move character

        //Rotate character to face the Movement direction 
        if (velocity.magnitude > 0)
        {
            smoothSpeed = Mathf.Lerp(smoothSpeed, moveSpeed, Time.deltaTime);
            characterMesh.rotation = Quaternion.LookRotation(velocity);
        }
        else
        {
            smoothSpeed = Mathf.Lerp(smoothSpeed, 0f, Time.deltaTime);
        }

    }

    private void FixedUpdate()
    {
        if (velocity.magnitude > 0)
            rb.velocity = new Vector3(velocity.normalized.x * smoothSpeed, rb.velocity.y, velocity.normalized.z * smoothSpeed);
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
                    moveSpeed = 5;
                    break;
                }
            case MovingState.Jogging:
                {
                    moveSpeed = 10;
                    break;
                }
            case MovingState.Spriting:
                {
                    moveSpeed = 15;
                    break;
                }
            case MovingState.Crouching:
                {
                    moveSpeed = 3;
                    break;
                }
        }
        //Debug.Log(state);
    }//end SetMovingState

    public MovingState GetMovingState()
    {
        return movingState;
    }
}