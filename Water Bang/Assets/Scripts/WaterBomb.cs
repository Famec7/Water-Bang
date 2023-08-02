using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBomb : Item
{
    [SerializeField]
    private int radius;
    private Vector3 mousePoint;

    public GameObject range;

    public override void UseItem()
    {
        mousePoint = Input.mousePosition;
        mousePoint = Camera.main.ScreenToWorldPoint(mousePoint);
        range.transform.position = new Vector3(mousePoint.x, mousePoint.y, 0);
        range.transform.localScale = new Vector3(radius * 2, radius * 2, 0);
        range.SetActive(true);
        if (Input.GetMouseButtonUp(0))
        {
            Collider2D[] colls = Physics2D.OverlapCircleAll(mousePoint, radius);

            foreach (Collider2D col in colls)
            {
                if (col.CompareTag("Enemy"))
                {
                    Debug.Log("Bomb");
                    col.gameObject.GetComponent<Character>().currentState = States.Exit;
                }
            }
            range.SetActive(false);
        }
    }
}
