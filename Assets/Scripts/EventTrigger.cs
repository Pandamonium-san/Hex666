using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventTrigger : MonoBehaviour {

    public AudioClip clip;
    public List<string> dialogue;
    public bool destroyAfterTriggered;
    public bool requiresItem;
    public int itemUsedToTrigger = -1;
    GameManager gm;

    protected virtual void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public virtual void Trigger()
    {
        if (clip)
            AudioSource.PlayClipAtPoint(clip, transform.position);
        if (dialogue != null && dialogue.Count > 0)
        {
            Queue<string> q = new Queue<string>(dialogue);
            gm.PlayMessage(q);
        }
        if (destroyAfterTriggered)
            Destroy(gameObject);
    }

    public virtual bool Trigger(Item item)
    {
        if (itemUsedToTrigger != -1 && item.ID != itemUsedToTrigger)
        {
            gm.PlayMessage("Nothing happened");
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
