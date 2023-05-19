using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator playerAnimation;




    public void StartAnimation()
    {
        playerAnimation.SetBool("startGame", true);
    }

    public void EndAnimation()
    {
        playerAnimation.Play("broken");
    }
}
