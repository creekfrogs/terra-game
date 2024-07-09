using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Rigidbody rigidbody;

    protected virtual void Awake()
    {
        DontDestroyOnLoad(this);

        rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {

    }

    protected virtual void LateUpdate()
    {

    }
}
