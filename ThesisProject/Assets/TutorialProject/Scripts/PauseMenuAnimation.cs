using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenuAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    Animation popUp;


  
    private void Awake()
    {
        popUp = GetComponent<Animation>();
    }
    private void AtEndOfAnimation()
    {
        Time.timeScale = 0f;
    }

}
