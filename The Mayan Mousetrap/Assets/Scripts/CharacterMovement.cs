using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Variables
    public float moveSpeed = 8f;

    //Components
    public Transform characterMesh;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move character
        transform.Translate(velocity.normalized * moveSpeed * Time.deltaTime);

        //Rotate character to face the Movement direction 
        if (velocity.magnitude > 0)
        {
            characterMesh.rotation = Quaternion.LookRotation(velocity);
        }
    }

    //Get and set velocity
    public Vector3 Velocity { get => velocity; set => velocity = value; }

}
