using UnityEngine;
using System.Collections;

public class BoneTrigger : EventTrigger {
    public override void Trigger(Player player)
    {
        player.Bone = true;
        Destroy(this.gameObject);
    }
}
