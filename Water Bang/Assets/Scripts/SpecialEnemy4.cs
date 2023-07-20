using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy4 : Character
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Character"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
