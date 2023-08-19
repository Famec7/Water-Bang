using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public float speed;
    private Vector3 mousePoint;
    private Vector3 dir;

    public void Move()
    {
        mousePoint = Input.mousePosition;
        mousePoint = Camera.main.ScreenToWorldPoint(mousePoint);
        mousePoint = new Vector3(mousePoint.x, mousePoint.y, 0);
        dir = mousePoint - this.transform.position;
        dir = dir.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Update()
    {
        if (this.gameObject.activeSelf)
        {
            this.transform.position += dir * speed * Time.unscaledDeltaTime;

            if (Vector2.Distance(transform.position, mousePoint) < 0.3)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
