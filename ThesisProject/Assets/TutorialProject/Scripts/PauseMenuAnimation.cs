using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenuAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    Animation popUp;


    private void Start()
    {
        
    }
    private void Awake()
    {
        popUp = GetComponent<Animation>();
        if (!popUp.isPlaying)
        {
            popUp.Play();
        }
        StartCoroutine(WaitForAnimation());
    }
    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(1f);
        while (popUp.isPlaying)
        {

        }
        Time.timeScale = 0f;
    }

}
