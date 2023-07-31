using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    [SerializeField]
    private float patience;
    public float amountPertick;

    public float Patience
    {
        get { return patience; }
        set
        {
            if (patience <= 0)
            {
                currentState = States.Exit;
                patience = 0;
            }
            else
                patience = value;
        }
    }

    protected override void Update()
    {
        base.Update();
    }

    public void DecreasePatience()
    {
        Patience -= amountPertick;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
