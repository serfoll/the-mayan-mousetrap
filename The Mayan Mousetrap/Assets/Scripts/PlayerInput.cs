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
        characterCtrl.verticalInput = Input.GetAxis("Vertical");
        characterCtrl.horizontalInput = Input.GetAxis("Horizontal");
    }
}
