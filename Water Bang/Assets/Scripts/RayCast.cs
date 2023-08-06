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
    GameObject player;
    [SerializeField]
    GameObject pause;
    [SerializeField]
    GameObject gameManager;

    void Start()
    {
        cam = GetComponent<Camera>();
        manager = gameManager.GetComponent<ScoreManager>();
    }

    void Update()
    {
        if (!pause.GetComponent<Pause>().isPause)
        {
            if (Input.GetMouseButton(0))
            {
                MousePosition = Input.mousePosition;
                MousePosition = cam.ScreenToWorldPoint(MousePosition);

                RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, rayDistance);
                Debug.DrawRay(MousePosition, transform.forward * 10, Color.red, 0.2f);

                if (hit && !player.GetComponent<WaterGun>().isReloading)
                {
                    if (hit.collider.tag == "Enemy") {
                        //hit.collider.gameObject.GetComponent<Character>().DestroyCharacter();
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
                    if (hit.collider.tag == "Item")
                    {

                    }
                }
            }
        }
    }
}