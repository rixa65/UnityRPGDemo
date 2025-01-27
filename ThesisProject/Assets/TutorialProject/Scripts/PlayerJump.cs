using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerJump : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody characterRB;
    [SerializeField] float jumpForce = 20f;
    //RaycastHit hit;
    void Start()
    {
        characterRB =  GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnJump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.3f))
        {
            {
                characterRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
            

            
    }

}
