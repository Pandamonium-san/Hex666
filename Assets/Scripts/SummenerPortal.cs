using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SummenerPortal : MonoBehaviour 
{
    int portalValue = 0;
    int itemsAdded = 0;

    bool playerIsInPortal = false;

    public void AddItemToSumeningPortal(int index)
    {
        DialogueScript diag = FindObjectOfType<DialogueScript>();
        if (playerIsInPortal && itemsAdded < 3)
        {
            itemsAdded++;
            portalValue += index;
            if (itemsAdded < 3)
                return;
            if(19 == portalValue)
            {
                diag.WaldBadEnd();
                // bad ending 1
            }
            else if (35 == portalValue)
            {
                diag.NoxBadEnd();
                // bad ending 2
            }
            else if (28 == portalValue)
            {
                diag.WaldGoodEnd();
                // good ending 1
            }
            else if (44 == portalValue)
            {
                diag.NoxGoodEnd();
                // good ending 2
            }
            else if(itemsAdded <= 3)
            {
                FindObjectOfType<GameManager>().PlayMessage("You lose!");
                Application.Quit();
                // you lose
            }
        }
    }

    public void DisableButton(GameObject button)
    {
        if (!playerIsInPortal || itemsAdded > 3)
            return;
        Destroy(button);
    }

    public void AddItemToProtal(Sprite sprite)
    {
        if (!playerIsInPortal)
            return;
        if (itemsAdded == 0)
            GameObject.Find("LeftItem").GetComponent<SpriteRenderer>().sprite = sprite;
        if (itemsAdded == 1)
            GameObject.Find("MidItem").GetComponent<SpriteRenderer>().sprite = sprite;
        if (itemsAdded == 2)
            GameObject.Find("RightItem").GetComponent<SpriteRenderer>().sprite = sprite;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        playerIsInPortal = true;
    }
    
    public void OnTriggerExit2D()
    {
        playerIsInPortal = false;
    }
}
