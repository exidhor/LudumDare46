using UnityEngine;
using System.Collections.Generic;
using Tools;

public class ItemManager : MonoSingleton<ItemManager>
{
    List<Item> _items = new List<Item>();

    public void Register(Item item)
    {
        _items.Add(item);
    }

    public void Unregister(Item item)
    {
        _items.Remove(item);
    }
}
