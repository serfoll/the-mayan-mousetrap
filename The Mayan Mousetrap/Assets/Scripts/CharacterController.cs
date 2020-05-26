using UnityEngine;

public class CharacterController : MonoBehaviour
{

    float horizontalInput, verticalInput;
    Vector3 velocity;
    //Components
    public CameraController cameraCtrl;
    public CharacterMovement characterMovement;
    public CharacterAnimController characterAnimCtrl;


    public void AddMovementInput(float verticalAxis, float horizontalAxis)
    {
        verticalInput = verticalAxis;
        horizontalInput = horizontalAxis;

        //New vector3 based on camera vertical,horizontal rotation and user vertical,horizontal axis input
        Vector3 translation = verticalAxis * cameraCtrl.transform.forward;
        translation += horizontalAxis * cameraCtrl.transform.right;
        //Stop character from moving up and down
        translation.y = 0;

        //Set velocity to translation if the translation magnitude(vector length) is greater then 0
        if (translation.magnitude > 0)
        {
            velocity = translation;
        }
        else
        {
            velocity = Vector3.zero;
        }

        characterMovement.Velocity = translation;

    }// end AddMovementinput

    //Get length of the velocitry vector
    public float GetVelocity()
    {
        //Debug.Log(characterMovement.Velocity.magnitude);
        return characterMovement.Velocity.magnitude;
    }

    //public void ToggleRun()
    //{
    //    if (characterMovement.GetMovingState() != CharacterMovement.MovingState.Jogging)
    //    {
    //        characterMovement.SetMovingState(CharacterMovement.MovingState.Jogging);
    //        characterAnimCtrl.SetMovingState(CharacterAnimController.MovingState.Jogging);
    //    }
    //    else
    //    {
    //        characterMovement.SetMovingState(CharacterMovement.MovingState.Walking);
    //        characterAnimCtrl.SetMovingState(CharacterAnimController.MovingState.Walking);
    //    }
    //}
    
    public void ToggleCrouch()
    {
        if (characterMovement.GetMovingState() != CharacterMovement.MovingState.Crouching)
        {
            characterMovement.SetMovingState(CharacterMovement.MovingState.Crouching);
            characterAnimCtrl.SetMovingState(CharacterAnimController.MovingState.Crouching);
        }
        else
        {
            characterMovement.SetMovingState(CharacterMovement.MovingState.Walking);
            characterAnimCtrl.SetMovingState(CharacterAnimController.MovingState.Walking);
        }
    }
    
    public void ToggleSprint(bool sprinting)
    {
        if (sprinting)
        {
            characterMovement.SetMovingState(CharacterMovement.MovingState.Spriting);
            characterAnimCtrl.SetMovingState(CharacterAnimController.MovingState.Spriting);
        }
        else
        {
            characterMovement.SetMovingState(CharacterMovement.MovingState.Jogging);
            characterAnimCtrl.SetMovingState(CharacterAnimController.MovingState.Jogging);
        }
    }
}
