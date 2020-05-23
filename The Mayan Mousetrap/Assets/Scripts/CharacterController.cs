using UnityEngine;

public class CharacterController : MonoBehaviour
{

    float horizontalInput, verticalInput;
    Vector3 velocity;
    //Components
    public CameraController cameraCtrl;

    // Start is called before the first frame update
    void Start()
    {
        //cameraCtrl = GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity);
    }

    //Update movement inputs
    public void AddMovementInput(float verticalAxis, float horizontalAxis)
    {
        verticalInput = verticalAxis;
        horizontalInput = horizontalAxis;

        //New vector3 based on camera vertical,horizontal rotation and user vertical and horizontal axis input
        Vector3 translation = verticalAxis * cameraCtrl.transform.forward;
        translation += horizontalAxis * cameraCtrl.transform.right;
        //Stop character from moving up and down
        translation.y = 0;

        if (translation.magnitude > 0)
        {
            velocity = translation;
        }
        else
        {
            velocity = Vector3.zero;
        }

    }
}
