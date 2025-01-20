using System;
using UnityEngine;

public class AnimalAnimation
{
    private Animator _animator;

    private AnimalAI _ai;

    public AnimalAnimation(AnimalAI ai, Animator animator)
    {
        _ai = ai;
        _animator = animator;
    }

    public void Update()
    {
        _animator.SetBool("IsMoving", _ai.IsMoving);
    }
}
