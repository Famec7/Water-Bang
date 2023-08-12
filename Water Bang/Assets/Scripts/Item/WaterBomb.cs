using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBomb : Item
{
    [SerializeField]
    private int radius;
    private Vector3 mousePoint;

    public GameObject range;
    public GameObject splashPrefab;

    private AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        range = transform.GetChild(0).gameObject;
        range.SetActive(false);
    }

    public override void UseItem()
    {
        mousePoint = Input.mousePosition;
        mousePoint = Camera.main.ScreenToWorldPoint(mousePoint);
        mousePoint = new Vector3(mousePoint.x, mousePoint.y, 0);
        range.transform.position = mousePoint;
        range.transform.localScale = new Vector3(radius * 10, radius * 10, 0);
        range.SetActive(true);
        if (Input.GetMouseButtonUp(0))
        {
            range.SetActive(false);
            GameObject splash = Instantiate(splashPrefab, mousePoint, transform.rotation);
            StartCoroutine("Attack");
            GameManager.instance.player.bombCount--;
        }
    }

    private IEnumerator Attack()
    {
        inUse = true;
        audioSource.PlayOneShot(clip);
        Collider2D[] colls = Physics2D.OverlapCircleAll(mousePoint, radius);

        foreach (Collider2D col in colls)
        {
            if (col.CompareTag("Enemy"))
            {
                col.gameObject.GetComponent<Character>().currentState = States.Exit;
            }
        }
        range.SetActive(false);

        yield return new WaitForSeconds(0.8f);
        inUse = false;
    }
}
