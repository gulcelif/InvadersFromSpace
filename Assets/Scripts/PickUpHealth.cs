using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealth : PickUps
{

    public override void PickMeUp()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AddHealth();
        gameObject.SetActive(false);
    }
}
