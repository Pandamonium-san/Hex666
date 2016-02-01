using UnityEngine;
using System.Collections;

public class WaldTrigger : EventTrigger {
    bool TalkingToWald;
    public override void Trigger()
    {
        if (!TalkingToWald)
        {
            DialogueScript.TalkingToWald();
            TalkingToWald = true;
        }
    }

    public override bool Trigger(Item item)
    {
        return false;
    }
}
