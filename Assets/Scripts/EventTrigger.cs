using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventTrigger : MonoBehaviour {

    public AudioClip clip;
    public List<string> dialogue;
    public bool destroyAfterTriggered;
    public bool requiresItem;
    public int itemUsedToTrigger;
    GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public virtual void Trigger()
    {
        if (requiresItem)
            return;
        if (clip)
            AudioSource.PlayClipAtPoint(clip, transform.position);
        if (dialogue.Count > 0)
        {
            Queue<string> q = new Queue<string>(dialogue);
            gm.PlayMessage(q);
        }
        if (destroyAfterTriggered)
            Destroy(gameObject);
    }

    public virtual bool Trigger(Item item)
    {
        if (item.ID != itemUsedToTrigger)
        {
            return false;
        }
        if (clip)
            AudioSource.PlayClipAtPoint(clip, transform.position);
        if (dialogue.Count > 0)
        {
            Queue<string> q = new Queue<string>(dialogue);
            gm.PlayMessage(q);
        }
        if (destroyAfterTriggered)
            Destroy(gameObject);
        return true;
    }
}
