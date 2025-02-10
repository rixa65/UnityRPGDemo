using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    Animation popUp;


    // Update is called once per frame
    private void Awake()
    {
        popUp = GetComponent<Animation>();
        popUp.Play();
    }
}
