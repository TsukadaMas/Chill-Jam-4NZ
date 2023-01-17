using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteAnimator : MonoBehaviour
{
    [SerializeField] private float transitionTime = 0f;
    [SerializeField] private int layer = 0;
    [SerializeField] PlayerMovement controller;
    [SerializeField] Animator animator;

    private int _currentState;
    private float _lockedUntill;

    //hashed states
    private static readonly int Idle = Animator.StringToHash("Player_Idle");
    private static readonly int Moving = Animator.StringToHash("Player_Moving");

    void Update()
    {
        var state = GetState();
        animator.CrossFade(state, transitionTime, layer);
    }

    private int GetState()
    {
        if (Time.time < _lockedUntill) return _currentState;

        return controller.inMovement == false ? Idle : Moving;

        //int LockState(int lockedState, float addedTime) {
        //    _lockedUntill = Time.time + addedTime;
        //    return lockedState;
        //}
    }

    public bool IsInRange(double value, double bound1, double bound2) => (value >= Math.Min(bound1, bound2) && value <= Math.Max(bound1, bound2));
}
