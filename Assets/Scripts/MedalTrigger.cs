using UnityEngine;
using System.Collections;

public class MedalTrigger : EventTrigger {
    public GameObject ButtonMedal;
    public override void Trigger(Player player)
    {
        ButtonMedal.SetActive(true);
        Destroy(gameObject);
    }
}
