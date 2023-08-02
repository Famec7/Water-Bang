using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whistle : Item
{
    public override void UseItem()
    {
        ObjectPool.instance.Reset();
    }
}
