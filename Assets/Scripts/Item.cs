using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Item
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public int Karma { get; private set; }

    public enum Type { Ingredient, Key, Catalyst }
    public Type type { get; set; }

    public Item(int ID, string Name, int Karma, Type type)
    {
        this.ID = ID;
        this.Name = Name;
        this.Karma = Karma;
        this.type = type;
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

    static void AddItemToDB(int id, string name, int karma, Type type)
    {
        DB.Add(id, new Item(id, name, karma, type));
        ++Count;
    }
    static void AddItemToDB(int id, string name, int karma)
    {
        DB.Add(id, new Item(id, name, karma, Type.Ingredient));
        ++Count;
    }

    public static void InitializeItemDB()
    {
        InitializeSprites();
        AddItemToDB(0, "RedMushroom", -4);
        AddItemToDB(1, "Bone", -2);
        AddItemToDB(2, "Medallion", 2);
        AddItemToDB(3, "Flask", 1);
        AddItemToDB(4, "Egg", 1);
        AddItemToDB(5, "Eyeball", -6);
        AddItemToDB(6, "Can", -1);
        AddItemToDB(7, "GoatHead", -3);
        AddItemToDB(8, "Lavender1", 1);
        AddItemToDB(9, "Money", 1);

        AddItemToDB(10, "PurpleCandle", 0, Type.Catalyst);
        AddItemToDB(11, "GreenCandle", 0, Type.Catalyst);
        AddItemToDB(12, "BlackHair", 0, Type.Catalyst);
        AddItemToDB(13, "NoxHair", 0, Type.Catalyst);

        AddItemToDB(14, "BluePotion", 0, Type.Key);
        AddItemToDB(15, "GreenPotion", 0, Type.Key);
        AddItemToDB(16, "YellowPotion", 0, Type.Key);
        AddItemToDB(17, "RedPotion", 0, Type.Key);
        AddItemToDB(18, "Note2", 0, Type.Key);
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

