using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Whistle whistle;
    private WaterBomb bomb;

    private Vector3 mousePoint;
    private Animator animator;

    public int whistleCount = 0;
    public int bombCount = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        whistle = GetComponent<Whistle>();
        bomb = GetComponent<WaterBomb>();
    }
    private void Update()
    {
        mousePoint = Input.mousePosition;
        mousePoint = Camera.main.ScreenToWorldPoint(mousePoint);
        mousePoint = new Vector3(mousePoint.x, mousePoint.y, 0);
        if (Input.GetKeyDown(KeyCode.Alpha1) && whistleCount > 0)
        {
            whistle.UseItem();
            whistleCount--;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            bomb.UseItem();
            bombCount--;
        }
        else if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        else
            bomb.range.SetActive(false);

        SetAnimation();
    }

    private void Shoot()
    {
        GameObject waterDrop = ObjectPool.instance.GetObject("waterDrop");
        if (waterDrop != null)
        {
            waterDrop.transform.position = this.gameObject.transform.position;
            waterDrop.SetActive(true);
        }
    }

    private void SetAnimation()
    {
        if(mousePoint.x < 0)
        {
            animator.SetBool("LeftShoot", true);
            animator.SetBool("RightShoot", false);
        }
        else
        {
            animator.SetBool("LeftShoot", false);
            animator.SetBool("RightShoot", true);
        }
    }
}
