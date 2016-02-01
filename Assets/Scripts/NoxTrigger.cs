using UnityEngine;
using System.Collections;

public class NoxTrigger : EventTrigger {

    int noxFlag;

    public override void Trigger()
    {
        if (noxFlag == 0)
        {
            DialogueScript.TalkingToNox();
            noxFlag = 1;
        }
        else if (noxFlag == 1)
        {
            DialogueScript.TalkingToNox1();
            noxFlag = 2;
        }
        else if (noxFlag == 2)
        {
            DialogueScript.TalkingToNox2();
            noxFlag = 3;
        }
        else if (noxFlag == 3)
        {
            DialogueScript.TalkingToNox3NoNote();
            noxFlag = 4;
        }
    }

    public override bool Trigger(Item item)
    {
        if (noxFlag == 3)
        {
            DialogueScript.TalkingToNox3Note();
            noxFlag = 4;
            return true;
        }
        return false;
    }
}
