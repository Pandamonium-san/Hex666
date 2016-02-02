using UnityEngine;
using System.Collections;

public class NoxTrigger : EventTrigger
{

    public override void Trigger()
    {
        DialogueScript.Nox();
    }

    public override bool Trigger(Item item)
    {
        return DialogueScript.Nox(item);
    }
}
