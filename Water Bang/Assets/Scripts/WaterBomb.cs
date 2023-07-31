using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBomb : Item
{
    [SerializeField] private int radius;
    private Vector3 mousePoint;

    public override void UseItem()
    {
        if (Input.GetMouseButtonUp(0))
        {
            mousePoint = Input.mousePosition;
            mousePoint = Camera.main.ScreenToWorldPoint(mousePoint);
            Collider2D[] colls = Physics2D.OverlapCircleAll(mousePoint, radius);

            foreach (Collider2D col in colls)
            {
                if (col.CompareTag("Enemy"))
                {
                    Debug.Log("Bomb");
                    col.gameObject.GetComponent<Character>().currentState = States.Exit;
                }
            }
        }
    }
}
