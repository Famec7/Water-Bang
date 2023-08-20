using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public float speed;
    private Vector3 mousePoint;
    private Vector3 dir;

    private GameObject center;

    private void Awake()
    {
        center = this.transform.GetChild(0).gameObject;
    }
    public void Move()
    {
        mousePoint = Input.mousePosition;
        mousePoint = Camera.main.ScreenToWorldPoint(mousePoint);
        mousePoint = new Vector3(mousePoint.x, mousePoint.y, 0);
        dir = mousePoint - center.transform.position;
        dir = dir.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Update()
    {
        if (this.gameObject.activeSelf)
        {
            this.transform.position += dir * speed * Time.unscaledDeltaTime;

            if (Vector2.Distance(transform.position, mousePoint) < 1.0)
            {
                this.gameObject.SetActive(false);
            }
        }

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f || pos.x > 1f || pos.y < 0f || pos.y > 1f)
            this.gameObject.SetActive(false);
    }
}
