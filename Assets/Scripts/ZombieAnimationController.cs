using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimationController : MonoBehaviour
{
    [SerializeField] private ConusCollisionDetect conusCollisionDetect;
    private Enemy enemy;
    [Header("Animation")]
    [SerializeField] private Animator _animator;
    private AnimationState _currentAnimation;
    private string _animatorParameterName;
    private bool playerInTarget = false;
    private bool playerCollision = false;
    private bool enemyDead = false;
      
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        _animatorParameterName = _animator.GetParameter(0).name;
        Debug.Log(_animatorParameterName);
    }

    // Update is called once per frame
    void Update()
    {
        GetTarget();
        GetCollisionPlayer();
        GetDead();
        PlayAnimation(AnimationState.zRunInPlace, playerInTarget && !enemyDead);
        PlayAnimation(AnimationState.zAttack, playerCollision && !enemyDead);
        PlayAnimation(AnimationState.zFallingBack, enemyDead);
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

    private void GetCollisionPlayer()
    {
        playerCollision = enemy.TakeThePlayerCollision();
    }

    private void GetDead()
    {
        enemyDead = enemy.TakeDead();
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
