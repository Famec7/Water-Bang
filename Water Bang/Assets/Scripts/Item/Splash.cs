using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.Play("Splash", -1);
/*        this.gameObject.transform.position += Vector3.down * 100f * Time.deltaTime;*/
        Destroy(this.gameObject, 0.6f);

        if (GameManager.instance.currentState == GameStates.gameOver || GameManager.instance.currentState == GameStates.gameClear)
            Destroy(this.gameObject);
    }
}
