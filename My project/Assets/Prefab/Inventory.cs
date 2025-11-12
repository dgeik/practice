using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Inventory
{
    private List<InventorySlot> _slots = new List<InventorySlot>();
    private int _capacity = 8;
    public InventorySlot GetItem(string name) => _slots.Find(i => i.item.nameItem == name);
    public List<InventorySlot> getInventory { get { return _slots; } }
    public float getCapacity { get { return _capacity; } }
    public void RemoveAt(int index)
    {
        if (index >= 0 && index < _slots.Count)
            _slots.RemoveAt(index);
    }
    public bool Add(Item item, float count)
    {
        foreach (var slot in _slots)
        {
            if (slot.item.nameItem == item.nameItem)
            {
                slot.count += count;
                return true;
            }
        }
        
        if (_slots.Count >= _capacity)
        {
            return false;
        }
        _slots.Add(new InventorySlot(item, count));
        return true;
    }

    public void Remove(Item item, float count)
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i].item.nameItem == item.nameItem)
            {
                _slots[i].count -= count;
                if (_slots[i].count <= 0)
                    _slots.RemoveAt(i);
                return;
            }
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public Item item;
    public float count;

    public InventorySlot(Item item, float count)
    {
        this.item = item;
        this.count = count;
    }
}