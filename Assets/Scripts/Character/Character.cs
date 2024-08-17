
using System;

public class Character : BaseCharacter
{
    private Health health;

    public bool Selected { get; set; }

    private void OnEnable()
    {
        health = GetComponent<Health>();
        health.diedEvent += SetEnabled;

        Squad.characters.Add(this);
    }

    private void SetEnabled()
    {
        enabled = false;
    }

    private void OnDisable()
    {
        health.diedEvent += SetEnabled;

        Squad.characters.Remove(this);
    }
}
