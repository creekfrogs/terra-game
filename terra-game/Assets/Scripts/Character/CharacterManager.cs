using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [HideInInspector] public Rigidbody _rigidbody;
    [HideInInspector] public Animator _animator;

    protected virtual void Awake()
    {
        DontDestroyOnLoad(this);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {

    }

    protected virtual void LateUpdate()
    {

    }
}
