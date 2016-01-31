using UnityEngine;
using System.Collections;

public class BoneTrigger : EventTrigger {
    public AudioSource audio;

    public override void Trigger(Player player)
    {
        player.Bone = true;
        Instantiate(audio);
        Destroy(this.gameObject);
    }
}
