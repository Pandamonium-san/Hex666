using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SummoningPortal : EventTrigger
{
    public Vector2[] ingredientPositions;
    public AudioClip placeSound;

    [SerializeField]
    GameObject pickupCata;
    [SerializeField]
    GameObject[] pickups;

    [SerializeField]
    Item catalyst;

    [SerializeField]
    Item[] items;

    public int maxAttempts = 2;
    int attempts = 0;
    int ingredientCount = 0;
    int karma = 0;

    protected override void Start()
    {
        items = new Item[5];
        pickups = new GameObject[5];
        base.Start();
    }

    public override void Trigger()
    {
        Debug.Log("triggered portal");
        if(ingredientCount < 5 && catalyst == null)
        {
            DialogueScript.ExaminePortalNoIngsOrCata();
        }
        else if(catalyst == null)
        {
            DialogueScript.ExaminePortalNoCata();
        }
        else if(ingredientCount < 5)
        {
            DialogueScript.ExaminePortalNoIngs();
        }
        else
        {
            DialogueScript.ExaminePortalHasCataAndIngs();
        }
    }

    public override bool Trigger(Item item)
    {
        if (item.Name == "Flask")
        {
            return TryRitual();
        }
        return AddItemToCircle(item);
    }

    bool TryRitual()
    {
        if (ingredientCount < 5 && catalyst == null)
        {
            DialogueScript.ExaminePortalNoIngsOrCata();
            return false;
        }
        else if (catalyst == null)
        {
            DialogueScript.ExaminePortalNoCata();
            return false;
        }
        else if (ingredientCount < 5)
        {
            DialogueScript.ExaminePortalNoIngs();
            return false;
        }
        else
        {
            CreatePotion();
            return true;
        }
    }

    void CreatePotion()
    {
        karma = 0;
        for (int i = 0; i < items.Length; i++)
        {
            karma += items[i].Karma;
            Destroy(pickups[i]);
        }
        Destroy(pickupCata);
        if (catalyst.Name == "PurpleCandle" && karma >= 0)
            DialogueScript.CreateBluePotion();
        else if (catalyst.Name == "BlackHair" && karma < 0)
            DialogueScript.CreateYellowPotion();
        else if (catalyst.Name == "GreenCandle" && karma >= 0)
            DialogueScript.CreateGreenPotion();
        else if (catalyst.Name == "NoxHair" && karma < 0)
            DialogueScript.CreateRedPotion();
        else if (attempts >= 1)
        {
            DialogueScript.GameOver();
        }
        else
        {
            attempts += 1;
            DialogueScript.PotionFailed();
        }
    }

    bool AddItemToCircle(Item item)
    {
        for (int i = 0; i < pickups.Length; i++)
        {
            switch (item.type)
            {
                case Item.Type.Ingredient:
                    if (pickups[i] != null)
                        continue;
                    pickups[i] = CreateItemOnGround(item, i);
                    return true;
                case Item.Type.Key:
                    DialogueScript.KeyItemToPortal();
                    return false;
                case Item.Type.Catalyst:
                    if (pickupCata)
                    {
                        DialogueScript.CataExists();
                        return false;
                    }
                    catalyst = item;
                    CreateItemOnGround(item, i);
                    if (item.Name == "BlackHair" || item.Name == "NoxHair")
                        DialogueScript.HairToPortal();
                    else if (item.Name == "PurpleCandle" || item.Name == "GreenCandle")
                        DialogueScript.CandleToPortal();
                    return true;
            }
        }
        DialogueScript.PortalFull();
        return false;
    }

    GameObject CreateItemOnGround(Item item, int pos)
    {
        //GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/Items/" + item.Name));
        if (placeSound)
            AudioSource.PlayClipAtPoint(placeSound, transform.position + new Vector3(0, 0, 10));

        GameObject go = new GameObject("Ingredient");
        SpriteRenderer spr = go.AddComponent<SpriteRenderer>();
        spr.sprite = Item.GetSprite(item.Name);
        spr.sortingOrder = -7;
        go.transform.parent = transform;
        go.layer = 9;
        if (item.type == Item.Type.Ingredient)
        {
            items[pos] = item;
            ++ingredientCount;
            go.transform.localPosition = ingredientPositions[pos];
        }
        else if (item.type == Item.Type.Catalyst)
        {
            go.transform.localPosition = Vector3.zero;
            pickupCata = go;
        }
        //go.AddComponent<BoxCollider2D>().isTrigger = true;
        //EventTrigger et = go.AddComponent<EventTrigger>();
        //et.destroyAfterTriggered = true;
        //et.dialogue = new List<string>();
        //et.dialogue.Add("AddItem " + item.ID);
        return go;
    }
}
