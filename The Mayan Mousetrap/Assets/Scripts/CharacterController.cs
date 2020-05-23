using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float horizontalInput, verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(horizontalInput, 0f, verticalInput));
    }

    //Update movement inputs
    public void AddMovementInput(float horisontalAxis, float verticalAxis)
    {
        horizontalInput = horisontalAxis;
        verticalInput = verticalAxis;
    }
}
