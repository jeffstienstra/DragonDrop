using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animating : MonoBehaviour
{
    private Animator _animator;
    // Update is called once per frame
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMoving(bool value)
    {
        _animator.SetBool("Moving", value);
    }

    public void Jump()
    {
        _animator.SetTrigger("Jump");
    }
}
