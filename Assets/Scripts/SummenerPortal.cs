using UnityEngine;
using System.Collections;

public class SummenerPortal : MonoBehaviour 
{
    int portalValue = 0;
    int itemsAdded = 0;

    public void AddItemToSumeningPortal(int index)
    {
        itemsAdded++;
        portalValue += index;
        if (itemsAdded < 3)
            return;
        if(19 == portalValue)
        {
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
