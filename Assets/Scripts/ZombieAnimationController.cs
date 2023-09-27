using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimationController : MonoBehaviour
{
    [SerializeField] private ConusCollisionDetect conusCollisionDetect;
    [Header("Animation")]
    [SerializeField] private Animator _animator;
    private AnimationState _currentAnimation;
    private string _animatorParameterName;
    private bool playerInTarget = false;
      
    // Start is called before the first frame update
    void Start()
    {
        _animatorParameterName = _animator.GetParameter(0).name;
        Debug.Log(_animatorParameterName);
    }

    // Update is called once per frame
    void Update()
    {
        GetTarget();
        PlayAnimation(AnimationState.zRunInPlace, playerInTarget);
    }

    private void PlayAnimation(AnimationState animationState, bool active)
        {
            if (animationState < _currentAnimation)
                return;

            if (!active)
            {
                if (animationState == _currentAnimation)
                {
                    _animator.SetInteger( _animatorParameterName, (int)AnimationState.zIdle);
                    _currentAnimation = AnimationState.zIdle;
                }
                
                return;
            }

            _animator.SetInteger( _animatorParameterName, (int)animationState);
            _currentAnimation = animationState;
        }

    private void GetTarget()
    {
        playerInTarget = conusCollisionDetect.TakeTheTarget();
    }

    private enum AnimationState
    {
        zIdle = 0,
        zWalkInPlace = 1,
        zWalk1InPlace = 2,
        zRunInPlace = 3,
        zAttack = 4,
        zFallingForward = 5,
        zFallingBack = 6,
    }
}
