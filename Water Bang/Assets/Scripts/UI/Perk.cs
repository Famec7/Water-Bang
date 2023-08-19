using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perk : MonoBehaviour
{
    public Sprite[] perkImages;
    private Image perkImage;

    public GameObject closeButton;

    private void Awake()
    {
        perkImage = GetComponent<Image>();
        this.gameObject.SetActive(false);
        closeButton.SetActive(false);
    }
    public void OnPerkButton()
    {
        perkImage.sprite = perkImages[GameManager.instance.currentStage];
        this.gameObject.SetActive(true);
        closeButton.SetActive(true);
    }
    public void OffPerk()
    {
        this.gameObject.SetActive(false);
        closeButton.SetActive(false);
    }
}
