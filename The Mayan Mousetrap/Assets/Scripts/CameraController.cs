using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Variables
    float xRotation, yRotation;
    Quaternion camRotation;
    public float camSmoothFactor = 1f;
    public float lookUpMax = 50f;
    public float lookUpMin = -50f;
    void Start()
    {
        camRotation = transform.localRotation;
    }

    void Update()
    {

        yRotation = Input.GetAxis("Mouse X");               // Get and set mouse x movement
        xRotation = Input.GetAxis("Mouse Y");               // Get and set  mouse y movement

        camRotation.x -= xRotation * camSmoothFactor;             // Look up/down
        camRotation.y += yRotation * camSmoothFactor;             // Look left/right

        camRotation.x = Mathf.Clamp(camRotation.x, lookUpMin, lookUpMax);           //clamping camera max and min look up/down angle
        
        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
    }
}
