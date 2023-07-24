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
        set { patience = value; }
    }

    public void DecreasePatience()
    {
        patience -= amountPertick;
        if (patience <= 0)
            DestroyCharacter();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.collider.CompareTag("water"))
            ObjectPool.instance.ReturnObject(this.gameObject);
    }
}
