using UnityEngine;
using System.Collections;

public class BoneTrigger : EventTrigger {
    public AudioSource audio;
    public GameObject ButtonBone;
    public override void Trigger(Player player)
    {
        ButtonBone.SetActive(true);
        Instantiate(audio);
        Destroy(this.gameObject);
    }
}
