using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 pointer;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        pointer = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        if (pointer.x < 0)
        {
            animator.SetBool("LeftShoot", true);
            animator.SetBool("RightShoot", false);
        }
        else
        {
            animator.SetBool("LeftShoot", false);
            animator.SetBool("RightShoot", true);
        }
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Shoot");
        }
    }
}
