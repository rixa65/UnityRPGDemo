using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody characterRB;
    CapsuleCollider characterCollider;
    Vector3 movementInput;
    Vector3 movementVector;
    float currentMovementSpeed;
    bool crouching = false;
    [SerializeField] float movementSpeed = 100f;
    [SerializeField] float crouchSpeedMultiplier = 0.5f;
    [SerializeField] float sprintSpeedMultiplier = 1.5f;
    [SerializeField] float crouchDepth = 1f;
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
        characterCollider = GetComponent<CapsuleCollider>();
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
        if(crouching)
        {
            currentMovementSpeed = movementSpeed;
            characterCollider.transform.localScale += new Vector3(0, crouchDepth / 2, 0);
            crouching =false;
        }
        else
        {
            currentMovementSpeed = movementSpeed * crouchSpeedMultiplier;
            characterCollider.transform.localScale -= new Vector3(0, crouchDepth / 2, 0);
            transform.localPosition -= new Vector3(0, crouchDepth, 0);
            crouching = true;
        }
        
    }

    private void OnMovementStop(InputValue input)
    {
        movementInput = Vector3.zero;
        
    }
    private void OnSprint()
    {
        if (!crouching)
        {
            currentMovementSpeed = movementSpeed * sprintSpeedMultiplier;
        }
    }
    private void OnSprintStop()
    {
        if (!crouching)
        {
            currentMovementSpeed = movementSpeed;
        }
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
