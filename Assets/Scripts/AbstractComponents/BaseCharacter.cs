using System;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    private Health health;

    public virtual void OnEnable()
    {
        health = GetComponent<Health>();
        health.diedEvent += SetEnabled;
    }

    private void SetEnabled()
    {
        enabled = false;
    }

    public virtual void OnDisable()
    {
        health.diedEvent -= SetEnabled;
    }
}
