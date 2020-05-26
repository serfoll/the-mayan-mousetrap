using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterAnimController : MonoBehaviour
{
    public enum MovingState { Walking, Jogging, Spriting, Crouching }

    //Components
    public Animator animator;
    CharacterController characterCtrl;
    MovingState movingState;

    // Start is called before the first frame update
    void Start()
    {
        //Set components
        characterCtrl = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Create eror in debug log if the animator is missing
        if(animator == null)
        {
            Debug.LogWarning("No valida animator");
            return;
        }

        animator.SetFloat("Velocity",characterCtrl.GetVelocity());
        //Debug.Log(characterCtrl.GetVelocity());
    }// end update


    public void SetMovingState(MovingState state)
    {
        movingState = state;
        switch (state)
        {
            case MovingState.Walking:
                {
                    animator.SetInteger("MovingState", 0);
                    break;
                }
            case MovingState.Jogging:
                {
                    animator.SetInteger("MovingState", 0);
                    break;
                }
            case MovingState.Spriting:
                {
                    animator.SetInteger("MovingState", 2);
                    break;
                }
            case MovingState.Crouching:
                {
                    animator.SetInteger("MovingState", 1);
                    break;
                }
        }
        Debug.Log(state);
    }//end SetMovingState
}
