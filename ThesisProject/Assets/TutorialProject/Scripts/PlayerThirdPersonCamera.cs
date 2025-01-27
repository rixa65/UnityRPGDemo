using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThirdPersonCamera : MonoBehaviour
{
    [SerializeField] Transform CameraHolderObjectTransform;

    [SerializeField] Vector3 Offset = new Vector3(0.5f, 0.5f, -2f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnThirdPersonCamera()
    {
        CameraHolderObjectTransform.transform.localPosition += Offset;
    }
    private void OnThirdPersonCameraStop()
    {
        CameraHolderObjectTransform.transform.localPosition -= Offset;
    }
}
