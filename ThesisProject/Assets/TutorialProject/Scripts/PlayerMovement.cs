using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody characterRB;
    Vector3 movementInput;
    Vector3 movementVector;
    float currentMovementSpeed;
    [SerializeField] float movementSpeed = 100f;
    [SerializeField] float crouchSpeedMultiplier = 0.5f;
    [SerializeField] float sprintSpeedMultiplier = 1.5f;
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
        movementVector = Vector3.zero;
        currentMovementSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ApplyMovement();
    }
    private void OnMovement(InputValue input)
    {
        movementInput = input.Get<Vector2>();   
    }
    private void OnCrouch() 
    {
        currentMovementSpeed = movementSpeed * crouchSpeedMultiplier;
    }
    private void OnCrouchStop()
    {
        currentMovementSpeed = movementSpeed;
    }
    private void OnMovementStop(InputValue input)
    {
        movementInput = Vector3.zero;
        
    }
    private void OnSprint()
    {
        currentMovementSpeed = movementSpeed * sprintSpeedMultiplier;
    }
    private void OnSprintStop()
    {
        currentMovementSpeed = movementSpeed;
    }
    private void ApplyMovement()
    {
        
        if (movementInput != null )
        {
            movementVector = Vector3.zero;
            movementVector += movementInput.x * transform.right;
            movementVector += movementInput.y * transform.forward;
            movementVector *= currentMovementSpeed * Time.fixedDeltaTime;
            movementVector.y = characterRB.velocity.y;

            characterRB.velocity = movementVector;
        }
    }

}
