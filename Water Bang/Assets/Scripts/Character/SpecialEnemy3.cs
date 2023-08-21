using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class SpecialEnemy3 : Character
{
    private float attackTime;
    [SerializeField] private float attackDuration;
    public Sprite[] blurImages;
    private Sprite blurImage;
    private GameObject blur;

    public AudioClip attackClip;

    protected override void Awake()
    {
        base.Awake();
        blur = transform.GetChild(0).gameObject;
        blur.gameObject.transform.SetParent(null);
        blur.transform.position = this.transform.position;
        attackTime = Random.Range(5, 10);
    }
    private void Start()
    {
        StartCoroutine("Attack");
        blurImage = blur.gameObject.GetComponent<SpriteRenderer>().sprite;
    }
    protected override void Update()
    {
        base .Update();
    }

    public IEnumerator Attack()
    {
        while (true)
        {
            // 공격X
            blur.SetActive(false);

            yield return new WaitForSeconds(attackTime);

            // 공격O
            sfx.PlayOneShot(attackClip);
            blur.transform.localScale = this.gameObject.transform.localScale * 5;
            blur.gameObject.GetComponent<SpriteRenderer>().sprite = blurImages[Random.Range(0, 2)];
            blur.SetActive(true);

            yield return new WaitForSeconds(attackDuration);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
    }

    private void OnDisable()
    {
        blur.SetActive(false);
        StopCoroutine("Attack");
    }
}
