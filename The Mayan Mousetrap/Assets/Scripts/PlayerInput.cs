using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerInput : MonoBehaviour
{
    private CharacterController characterCtrl;

    // Start is called before the first frame update
    void Start()
    {
        characterCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        // Add/define axisto character controll component 
        characterCtrl.AddMovementInput(verticalAxis, horizontalAxis);
    }
}
