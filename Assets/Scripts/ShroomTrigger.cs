using UnityEngine;
using System.Collections;

public class ShroomTrigger : EventTrigger {
    public override void Trigger(Player player)
    {
        ++player.Mushroom;
        Destroy(gameObject);
    }
}
