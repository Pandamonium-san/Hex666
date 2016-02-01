using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Item
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public int Karma { get; private set; }
    public bool IsIngredient { get; private set; }

    public Item(int ID, string Name, int Karma, bool IsIngredient)
    {
        this.ID = ID;
        this.Name = Name;
        this.Karma = Karma;
        this.IsIngredient = IsIngredient;
    }

    public static Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();
    public static Dictionary<int, Item> DB = new Dictionary<int, Item>();
    static int Count;

    public static Item GetItem(int id)
    {
        Item item;
        if (DB.TryGetValue(id, out item))
            return item;
        else
            return null;
    }
    public static Sprite GetSprite(string name)
    {
        Sprite sprite;
        if (sprites.TryGetValue(name, out sprite))
            return sprite;
        else
        {
            Debug.Log("Sprite not found");
            return null;
        }
    }

    static void AddItemToDB(string name, int karma, bool isIngredient)
    {
        DB.Add(Count, new Item(Count, name, karma, isIngredient));
        ++Count;
    }
    static void AddItemToDB(string name, int karma)
    {
        DB.Add(Count, new Item(Count, name, karma, true));
        ++Count;
    }

    public static void InitializeItemDB()
    {
        InitializeSprites();
        AddItemToDB("RedMushroom", -10);
        AddItemToDB("Bone", -2);
        AddItemToDB("Medallion", 2);
        AddItemToDB("Flask", 1);
    }

    static void InitializeSprites()
    {
        Sprite[] spr = Resources.LoadAll<Sprite>("Sprites/Items");
        for (int i = 0; i < spr.Length; i++)
        {
            sprites.Add(spr[i].name, spr[i]);
        }
    }

}

