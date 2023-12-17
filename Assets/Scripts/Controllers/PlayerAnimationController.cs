using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]  private Animator animator;
    public void ChangeAnimation(PlayerAnimationTypes _animationType)
    {
        if (_animationType == PlayerAnimationTypes.Run)
        {
            animator.Play("Running");
        }
        else
        {
            animator.SetTrigger(_animationType.ToString());
        }
    }
}

