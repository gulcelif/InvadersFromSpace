using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : PickUps
{
    public override void PickMeUp()
    {
        Inventory.currentCoins++;
        UIManager.UpdateCoins();
        gameObject.SetActive(false);
    }
}
