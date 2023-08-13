using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLife : PickUps
{
    public override void PickMeUp()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AddLive();

    }
}
