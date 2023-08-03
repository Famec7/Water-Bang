using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    float rayDistance = 15f;
    Vector3 MousePosition;
    Camera cam;

    [SerializeField]
    GameObject waterGun;
    [SerializeField]
    GameObject pause;
    [SerializeField]
    GameObject scoreManager;

    void Start()
    {
        cam = GetComponent<Camera>();
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

                if (hit && !waterGun.GetComponent<WaterGun>().isReloading)
                {
                    if (hit.collider.tag == "Enemy") {
                        hit.collider.gameObject.GetComponent<Character>().DestroyCharacter();
                        //hit.collider.gameObject.GetComponent<Character>().currentState = States.Exit;
                        scoreManager.GetComponent<ScoreManager>().Score += 5 + 10 * scoreManager.GetComponent<ScoreManager>().combo++;
                        Debug.Log(scoreManager.GetComponent<ScoreManager>().combo);
                    }
                    if (hit.collider.tag == "NPC")
                    {
                        hit.collider.gameObject.GetComponent<Character>().currentState = States.Exit;
                        scoreManager.GetComponent<ScoreManager>().Score -= 5;
                        scoreManager.GetComponent<ScoreManager>().combo = 0;
                    }
                }
            }
        }
    }
}