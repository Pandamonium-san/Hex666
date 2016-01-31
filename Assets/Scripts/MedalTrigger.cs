using UnityEngine;
using System.Collections;

public class MedalTrigger : EventTrigger {
    public override void Trigger(Player player)
    {
        player.Medallion = true;
        Destroy(gameObject);
    }
}
