using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Whistle whistle;
    private WaterBomb bomb;
    private EnergyDrink energyDrink;

    private Vector3 mousePoint;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public int whistleCount = 0;
    public int bombCount = 0;
    public int energyDrinkCount = 0;
    Vector3 leftMuzzlePos;
    Vector3 rightMuzzlePos;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        whistle = GetComponent<Whistle>();
        bomb = GetComponent<WaterBomb>();
        energyDrink = GetComponent<EnergyDrink>();
        leftMuzzlePos = this.transform.GetChild(1).transform.position;
        rightMuzzlePos = this.transform.GetChild(2).transform.position;
    }
    private void Update()
    {
        if (GameManager.instance.currentState == GameStates.inGame)
        {
            mousePoint = Input.mousePosition;
            mousePoint = Camera.main.ScreenToWorldPoint(mousePoint);
            mousePoint = new Vector3(mousePoint.x, mousePoint.y, 0);
            if (Input.GetKeyDown(KeyCode.Alpha1) && whistleCount > 0 && !whistle.inUse)
            {
                whistle.UseItem();
                whistleCount--;
            }
            else if (Input.GetKey(KeyCode.Alpha2) && bombCount > 0 && !bomb.inUse)
            {
                bomb.UseItem();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && energyDrinkCount > 0 && !energyDrink.inUse)
            {
                energyDrink.UseItem();
                energyDrinkCount--;
            }
            else if (Input.GetMouseButton(0) && GameManager.instance.waterGun.waterQuantity > 0)
            {
                Shoot();
            }
            else
                bomb.range.SetActive(false);

            SetAnimation();
        }
    }

    private void Shoot()
    {
        GameObject waterDrop = ObjectPool.instance.GetObject("waterDrop");
        if (waterDrop != null)
        {
            if (spriteRenderer.flipX)
                waterDrop.transform.position = rightMuzzlePos;
            else
                waterDrop.transform.position = leftMuzzlePos;
            waterDrop.SetActive(true);
        }
    }

    private void SetAnimation()
    {
        if (mousePoint.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    public void Reset()
    {
        whistleCount = 10;
        bombCount = 10;
        energyDrinkCount = 10;
        /*whistle.inUse = false;
        bomb.inUse = false;
        energyDrink.inUse = false;*/
    }
}
