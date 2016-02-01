using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class InventorySlot : MonoBehaviour
{
    public Item Item {
        get { return item; }
        set { item = value; spriteRenderer.sprite = Item.GetSprite(item.Name); }
    }

    SpriteRenderer spriteRenderer;
    Item item;

    public void Initialize(Item item)
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        Item = item;
        spriteRenderer.color = Color.white * 0.5f;
    }

    public void Selected(bool isSelected)
    {
        if (isSelected)
            spriteRenderer.color = Color.white;
        else
            spriteRenderer.color = Color.white * 0.5f;
    }
}
