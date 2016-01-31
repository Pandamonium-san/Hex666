using UnityEngine;
using System.Collections;

public class SummenerPortal : MonoBehaviour 
{
    bool MushroomPlazed = false;
    bool MedallionPlazed = false;
    bool BonePlazed = false;
    bool FlaskPlazed = false;
    bool CatOneLightPlazed = false;
    bool CatTwoLightPlazed = false;

    int portalValue = 0;

    public void AddItemToSumeningPortal(int index)
    {
        portalValue += index;

        if(19 == portalValue)
        {
            // bad ending 1
        }
        else if (35 == portalValue)
        {
            // bad ending 2
        }
        else if(16 + 4 + 8)
        {
            // good ending 1
        }
        else if(32 + 4 + 8)
        {
            // good ending 2
        }


    }
}
