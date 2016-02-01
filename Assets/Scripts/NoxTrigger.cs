using UnityEngine;
using System.Collections;

public class NoxTrigger : EventTrigger {
    bool TalkingToNox;
    public override void Trigger()
    {
        if (!TalkingToNox)
        {
            DialogueScript.TalkingToNox();
            TalkingToNox = true;
        }
    }
}
