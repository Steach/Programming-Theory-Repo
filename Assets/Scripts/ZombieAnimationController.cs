using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimationController : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator _animator;
    private AnimationState _currentAnimation;
    private string _animatorParametrName;
    private int speed;
      
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
