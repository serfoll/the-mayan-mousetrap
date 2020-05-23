using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterAnimController : MonoBehaviour
{
    //Components
    public Animator animator;
    CharacterController characterCtrl;
    // Start is called before the first frame update
    void Start()
    {
        characterCtrl = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator == null)
        {
            Debug.LogWarning("No valida animator");
            return;
        }

        animator.SetFloat("Velocity",characterCtrl.GetVelocity());
    }
}
