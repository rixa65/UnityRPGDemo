using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
}
public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Camera characterCamera;
    [SerializeField] float interactRange = 3f;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnInteract()
    {
        if(Physics.Raycast(characterCamera.transform.position, characterCamera.transform.forward, out hit, interactRange))
        {
            IInteractable hitInfo;
            hitInfo = hit.collider.GetComponent<IInteractable>();
            if(hitInfo != null)
            {
                hitInfo.Interact();
            }
        }
    }
}
