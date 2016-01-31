using UnityEngine;
using System.Collections;

public class WaldTrigger : EventTrigger {
    bool TalkingToWald;
    public override void Trigger(Player player)
    {
        if (!TalkingToWald)
        {
            FindObjectOfType<DialogueScript>().TalkingToWald();
            TalkingToWald = true;
        }
    }
}
