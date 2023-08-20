using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    float rayDistance = 15f;
    Vector3 MousePosition;
    Camera cam;

    [SerializeField]
    WaterGun player;

    public ScoreText scoreText;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (GameManager.instance.currentState == GameStates.inGame)
        {
            MousePosition = Input.mousePosition;
            MousePosition = cam.ScreenToWorldPoint(MousePosition);

            RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, rayDistance);
            Debug.DrawRay(MousePosition, transform.forward * 10, Color.red, 0.2f);
            if (Input.GetMouseButton(0))
            {

                if (hit && !player.isReloading)
                {
                    if (hit.collider.tag == "Enemy")
                    {
                        hit.collider.gameObject.GetComponent<Character>().currentState = States.Exit;
                    }
                    if (hit.collider.tag == "Npc")
                    {
                        hit.collider.gameObject.GetComponent<Character>().currentState = States.Exit;
                    }
                }

            }
            if (Input.GetMouseButtonDown(1))
            {
                if (hit)
                {
                    if (hit.collider.tag == "Whistle")
                    {
                        GameManager.instance.player.whistleCount++;
                        hit.collider.gameObject.SetActive(false);
                    }
                    else if (hit.collider.tag == "WaterBomb")
                    {
                        GameManager.instance.player.bombCount++;
                        hit.collider.gameObject.SetActive(false);
                    }
                    else if (hit.collider.tag == "EnergyDrink")
                    {
                        GameManager.instance.player.energyDrinkCount++;
                        hit.collider.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}