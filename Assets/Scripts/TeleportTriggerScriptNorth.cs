using UnityEngine;
using System.Collections;

public class TeleportTriggerScriptNorth : EventTrigger
{
    public override void Trigger(Player player)
    {
        Vector3 OldPos = player.transform.position;
        OldPos.y += 20;
        player.transform.position = OldPos;
	}
}
