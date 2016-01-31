using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SummenerPortal : MonoBehaviour 
{
    int portalValue = 0;
    int itemsAdded = 0;

    public void AddItemToSumeningPortal(int index)
    {
        DialogueScript diag = FindObjectOfType<DialogueScript>();
        if (itemsAdded < 3)
        {
            itemsAdded++;
            portalValue += index;
            if (itemsAdded < 3)
                return;
            if(19 == portalValue)
            {
                //diag.nox
                // bad ending 1
            }
            else if (35 == portalValue)
            {
                // bad ending 2
            }
            else if (28 == portalValue)
            {
                // good ending 1
            }
            else if (44 == portalValue)
            {
                // good ending 2
            }
        }
    }

    public void DisableButton(GameObject button)
    {
        if (itemsAdded > 3)
            return;
        Destroy(button);
    }

    public void AddItemToProtal(Sprite sprite)
    {
        if (itemsAdded == 0)
            GameObject.Find("LeftItem").GetComponent<SpriteRenderer>().sprite = sprite;
        if (itemsAdded == 1)
            GameObject.Find("MidItem").GetComponent<SpriteRenderer>().sprite = sprite;
        if (itemsAdded == 2)
            GameObject.Find("RightItem").GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
