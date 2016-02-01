using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public float slotPadding;
    public int selectedIndex;
    public Item SelectedItem { get { return slots[selectedIndex].Item; } }

    [SerializeField]
    private List<InventorySlot> slots;

    SpriteRenderer spr;

    void Start()
    {
        slots = new List<InventorySlot>();
    }

    public void ScrollForward()
    {
        if (selectedIndex >= slots.Count - 1)
            return;
        ++selectedIndex;
        UpdateSlots();
    }

    public void ScrollBack()
    {
        if (selectedIndex <= 0)
            return;
        --selectedIndex;
        UpdateSlots();
    }

    void UpdateSlots()
    {

        for (int i = 0; i < slots.Count; i++)
        {
            if (selectedIndex - 2 <= i && i <= selectedIndex + 2)
            {
                slots[i].gameObject.SetActive(true);

                if (i == selectedIndex)
                    slots[i].Selected(true);
                else
                    slots[i].Selected(false);
                slots[i].transform.localPosition = new Vector3(0, (i - selectedIndex) * slotPadding, 0);
            }
            else
            {
                slots[i].gameObject.SetActive(false);
            }
        }
    }

    public void AddSlot(Item item)
    {
        GameObject go = new GameObject("InventorySlot");
        InventorySlot slot = go.AddComponent<InventorySlot>();
        slot.Initialize(item);
        slot.transform.parent = transform;
        slots.Add(slot);
        UpdateSlots();
    }

    public void RemoveSelectedItem()
    {
        Debug.Log("removing item");
        InventorySlot removed = slots[selectedIndex];
        slots.RemoveAt(selectedIndex);
        Destroy(removed.gameObject);
        UpdateSlots();
    }
}
