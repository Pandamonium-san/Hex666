using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShroomTrigger : EventTrigger {
    Queue<string> que = new Queue<string>();

    public override void Trigger(Player player)
    {
        player.Mushroom = true;
        que.Enqueue("You found a mushroom!");
        que.Enqueue("Or did you?");
        que.Enqueue("...");
        FindObjectOfType<GameManager>().PlayMessage(que);
        Destroy(gameObject);
    }
}
