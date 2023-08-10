using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    float rayDistance = 15f;
    Vector3 MousePosition;
    Camera cam;
    ScoreManager manager;

    [SerializeField]
    WaterGun player;

    void Start()
    {
        cam = GetComponent<Camera>();
        manager = GameManager.instance.GetComponent<ScoreManager>();
    }

    void Update()
    {
        if (GameManager.instance.currentState != GameStates.pause)
        {
            if (Input.GetMouseButton(0))
            {
                MousePosition = Input.mousePosition;
                MousePosition = cam.ScreenToWorldPoint(MousePosition);

                RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, rayDistance);
                Debug.DrawRay(MousePosition, transform.forward * 10, Color.red, 0.2f);

                if (hit && !player.isReloading)
                {
                    if (hit.collider.tag == "Enemy")
                    {
                        hit.collider.gameObject.GetComponent<Character>().currentState = States.Exit;
                        manager.Score += 5 + 10 * manager.Combo++;
                        manager.isComboUp = true;
                    }
                    if (hit.collider.tag == "Npc")
                    {
                        hit.collider.gameObject.GetComponent<NPC>().currentState = States.Exit;
                        manager.Score -= 5;
                        manager.Combo = 0;
                        manager.isComboUp = true;
                    }
                }

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