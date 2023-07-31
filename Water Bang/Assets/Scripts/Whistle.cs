using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whistle : Item
{
    public override void UseItem()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("Npc");

        foreach (GameObject obj in enemies)
            obj.SetActive(false);
        foreach (GameObject obj in npcs)
            obj.SetActive(false);
    }
}
