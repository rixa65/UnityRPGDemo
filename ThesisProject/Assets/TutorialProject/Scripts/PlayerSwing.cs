using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    Animator characterAnimator;
    // Start is called before the first frame update
    void Start()
    {
        characterAnimator = GetComponent<Animator>();
    }

   private void OnAttack()
    {
        if(!characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Swing") && !characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        characterAnimator.SetTrigger("isSwinging");
    }
}
