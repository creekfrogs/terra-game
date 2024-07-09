using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorManager : MonoBehaviour
{
    CharacterManager character;

    protected virtual void Awake()
    {
        character = GetComponent<CharacterManager>();
    }

    public void UpdateAnimatorMovementParams(float horizontal, float vertical)
    {
        character._animator.SetFloat("horizontal", horizontal);
        character._animator.SetFloat("vertical", vertical);
    }
}
