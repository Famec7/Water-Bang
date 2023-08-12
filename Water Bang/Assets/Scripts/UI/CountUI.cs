using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountUI : MonoBehaviour
{
    public string itemName;
    private Text count;

    private void Awake()
    {
        count = GetComponent<Text>();
    }
    
    void Update()
    {
        if (itemName == "whistle")
            count.text = GameManager.instance.player.whistleCount.ToString();
        else if(itemName == "waterBomb")
            count.text = GameManager.instance.player.bombCount.ToString();
        else if(itemName == "energyDrink")
            count.text = GameManager.instance.player.energyDrinkCount.ToString();
    }
}
