﻿using UnityEngine;

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
        float horizontalAxis = Input.GetAxis("Horizontal") * Time.deltaTime;
        float verticalAxis = Input.GetAxis("Vertical") * Time.deltaTime;

        // Add/define axis to character controll component 
        characterCtrl.AddMovementInput(verticalAxis, horizontalAxis);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            characterCtrl.ToggleRun();

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            characterCtrl.ToggleCrouch();
        }
    }
}
