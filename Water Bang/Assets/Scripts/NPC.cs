using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    [SerializeField]
    private float patience;
    public float amountPertick;

    public void DecreasePatience()
    {
        patience -= amountPertick;
        if (patience <= 0)
            DestroyCharacter();
    }
}
