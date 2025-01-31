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
    bool thirdPersonCamera = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {   
        mouseX *= mouseSensitivity * Time.fixedDeltaTime;
        mouseY *= mouseSensitivity * Time.fixedDeltaTime;
        yRotation += mouseX;
        
        transform.rotation = Quaternion.Euler(0, yRotation, 0);

        if (!thirdPersonCamera)
        {
            xRotation = Mathf.Clamp(xRotation - mouseY, -60, 40);
            CameraHolderObjectTransform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        }
        
    }
    public void SetSensitivity(int newSensitivity)
    {
        mouseSensitivity=newSensitivity;
    }
    public int GetSensitivity()
    {
        return mouseSensitivity;
    }
    private void OnLook(InputValue input)
    {
        Vector2 mouseVector = input.Get<Vector2>();
        mouseX = mouseVector.x; 
        mouseY = mouseVector.y; 
    }
    private void OnThirdPersonCamera()
    {
        if (thirdPersonCamera)
        {
            thirdPersonCamera = false;
            CameraHolderObjectTransform.transform.localPosition -= Offset;
        }
        else
        {
            thirdPersonCamera = true;
            CameraHolderObjectTransform.transform.localPosition += Offset;
            CameraHolderObjectTransform.rotation = transform.rotation;
        }
    }
}
