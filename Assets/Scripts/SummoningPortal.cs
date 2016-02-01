using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SummoningPortal : EventTrigger
{
    public Vector2[] ingredientPositions;
    int maxItems = 6;
    int karma = 0;
    int itemsAdded = 0;
    bool playerIsInPortal = false;

    void Start()
    {
    }

    public override bool Trigger(Item item)
    {
        if (AddItemToCircle(item))
        {

            return true;
        }
        else
            return false;
        //if (dialogue.Count > 0)
        //{
        //    Queue<string> q = new Queue<string>(dialogue);
        //    gm.PlayMessage(q);
        //}
    }

    bool AddItemToCircle(Item item)
    {
        if (!item.IsIngredient || itemsAdded >= maxItems)
            return false;
        karma += item.Karma;
        GameObject go = new GameObject("Ingredient");
        SpriteRenderer spr = go.AddComponent<SpriteRenderer>();
        spr.sprite = Item.GetSprite(item.Name);
        spr.sortingOrder = -7;
        go.transform.parent = transform;
        if (itemsAdded < ingredientPositions.Length)
            go.transform.localPosition = ingredientPositions[itemsAdded++];
        else
            go.transform.localPosition = Vector3.zero;
        return true;
    }

    public void AddItemToSummoningPortal(int index)
    {
        if (playerIsInPortal && itemsAdded < 3)
        {
            itemsAdded++;
            karma += index;
            if (itemsAdded < 3)
                return;
            if (19 == karma)
            {
                DialogueScript.WaldBadEnd();
                // bad ending 1
            }
            else if (35 == karma)
            {
                DialogueScript.NoxBadEnd();
                // bad ending 2
            }
            else if (28 == karma)
            {
                DialogueScript.WaldGoodEnd();
                // good ending 1
            }
            else if (44 == karma)
            {
                DialogueScript.NoxGoodEnd();
                // good ending 2
            }
            else if (itemsAdded <= 3)
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
