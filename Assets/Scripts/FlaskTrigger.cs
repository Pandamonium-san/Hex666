using UnityEngine;
using System.Collections;

public class FlaskTrigger : EventTrigger {
    public override void Trigger(Player player)
    {
        ++player.Flask;
        Destroy(gameObject);
    }
}
