using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public float speed;
    private Vector3 mousePoint;

    private void Start()
    {
        StartCoroutine("Move");
    }

    private IEnumerator Move()
    {
        mousePoint = Input.mousePosition;
        mousePoint = Camera.main.ScreenToWorldPoint(mousePoint);
        mousePoint = new Vector3(mousePoint.x, mousePoint.y, 0);

        yield return null;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, mousePoint, speed * Time.unscaledDeltaTime);

        if (Vector2.Distance(transform.position, mousePoint) < 0.3)
        {
            StartCoroutine("Move");
            this.gameObject.SetActive(false);
        }
    }
}
