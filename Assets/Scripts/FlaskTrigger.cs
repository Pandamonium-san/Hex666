using UnityEngine;
using System.Collections;

public class FlaskTrigger : EventTrigger {
    public GameObject buttonFlask;
    public override void Trigger(Player player)
    {
        buttonFlask.SetActive(true);
        Destroy(gameObject);
    }
}
