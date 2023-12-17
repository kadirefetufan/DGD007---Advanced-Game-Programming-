using Enums;
using UnityEngine;

namespace Controllers
{
    public class CollectableAnimationController : MonoBehaviour
    {
        [SerializeField]  private Animator animator;

            public void ChangeAnimation(CollectableAnimationTypes _animationType)
        {
            animator.SetTrigger(_animationType.ToString());
        }
    }
}