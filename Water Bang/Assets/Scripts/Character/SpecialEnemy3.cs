using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class SpecialEnemy3 : Character
{
    [SerializeField] private float attackTime;
    [SerializeField] private float attackDuration;
    public Sprite[] blurImages;
    private Sprite blurImage;
    private GameObject blur;

    protected override void Awake()
    {
        base.Awake();
        blur = transform.GetChild(0).gameObject;
        blur.gameObject.transform.SetParent(null);
        blur.transform.position = this.transform.position;
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
        // 공격X
        blur.SetActive(false);
        yield return new WaitForSeconds(attackTime);

        // 공격O
        blur.transform.localScale = this.gameObject.transform.localScale * 30;
        blur.gameObject.GetComponent<SpriteRenderer>().sprite = blurImages[Random.Range(0, 2)];
        blur.SetActive(true);
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
    }
}
