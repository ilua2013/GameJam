using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Mover _mover;
    [SerializeField] private PlayerFighter _fighter;
    [SerializeField] private float _distanceToRun;

    enum State
    {
        Idle, Attack, Run, Move, Walk
    }

    private void Update()
    {
        _animator.SetBool(State.Move.ToString(), !_mover.IsStop); ;
    }

    private void OnEnable()
    {
        _mover.Moved_getPos += SetRun;
        _fighter.Killed += SetIdle;
        _fighter.Attacked += SetAttack;
    }

    private void OnDisable()
    {
        _mover.Moved_getPos -= SetRun;
        _fighter.Killed -= SetIdle;
        _fighter.Attacked -= SetAttack;
    }

    private void SetIdle()
    {
        _animator.ResetTrigger(State.Attack.ToString());
        _animator.SetTrigger(State.Idle.ToString());
    }

    private void SetAttack()
    {
        if (_fighter.IsFight == false)
            return;

        _animator.SetTrigger(State.Attack.ToString());
        print("AnimatorAttack");
    }

    private void SetRun(Vector3 pos)
    {
        if (Vector3.Distance(transform.position, pos) > _distanceToRun)
            _animator.SetTrigger(State.Run.ToString());
        else
            _animator.SetTrigger(State.Walk.ToString());
    }
}
