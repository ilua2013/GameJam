using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Mover _mover;
    [SerializeField] private PlayerFighter _fighter;

    enum State
    {
        Idle, Attack, Run
    }

    private void Update()
    {
        if (_mover.IsStop)
            SetIdle();
        else
            SetRun();
    }

    private void OnEnable()
    {
        _mover.Moved += SetRun;
        _mover.Stoped += SetIdle;
        _fighter.Attacked += SetAttack;
    }

    private void OnDisable()
    {
        _mover.Moved -= SetRun;
        _mover.Stoped -= SetIdle;
        _fighter.Attacked -= SetAttack;
    }

    private void SetIdle()
    {
        _animator.SetTrigger(State.Idle.ToString());
    }

    private void SetAttack()
    {
        _animator.SetTrigger(State.Attack.ToString());
    }

    private void SetRun()
    {
        _animator.SetTrigger(State.Run.ToString());
    }
}
