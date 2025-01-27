using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]  int mouseSensitivity = 20;
    [SerializeField] Transform CameraHolderObjectTransform;
    [SerializeField] Vector3 Offset = new Vector3(0.5f, 0.5f, -2f);
    float xRotation;
    float yRotation;
    float mouseX = 0;
    float mouseY = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {   
        mouseX = mouseSensitivity * mouseX * Time.fixedDeltaTime;
        mouseY = mouseSensitivity * mouseY * Time.fixedDeltaTime;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation-mouseY, -60, 60);
        CameraHolderObjectTransform.rotation = Quaternion.Euler(xRotation, yRotation,0    );
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
    private void OnLook(InputValue input)
    {
        Vector2 mouseVector = input.Get<Vector2>();
        mouseX = mouseVector.x; 
        mouseY = mouseVector.y; 
    }
}
