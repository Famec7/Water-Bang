using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SpecialEnemy3 : Character
{
    [SerializeField] private float attackTime;
    [SerializeField] private float attackDuration;
    private PostProcessVolume blur;
    private DepthOfField pr;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        blur = Camera.main.GetComponent<PostProcessVolume>();
        blur.sharedProfile.TryGetSettings<DepthOfField>(out pr);
        pr.focalLength.overrideState = false;
        StartCoroutine("Attack");
    }
    protected override void Update()
    {
        base .Update();
    }

    public IEnumerator Attack()
    {
        pr.focalLength.overrideState = false;
        yield return new WaitForSeconds(attackTime);

        pr.focalLength.overrideState = true;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
