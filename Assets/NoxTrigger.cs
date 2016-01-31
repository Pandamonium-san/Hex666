using UnityEngine;
using System.Collections;

public class NoxTrigger : EventTrigger {
    bool TalkingToNox;
    public override void Trigger(Player player)
    {
        if (!TalkingToNox)
        {
            FindObjectOfType<DialogueScript>().TalkingToNox();
            TalkingToNox = true;
        }
    }
}
