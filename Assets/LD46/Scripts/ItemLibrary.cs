using UnityEngine;
using System.Collections.Generic;
using Tools;

public class ItemLibrary : MonoSingleton<ItemLibrary>
{
    public List<Item> items;

    public Item GetItem()
    {
        return Instantiate(items[Random.Range(0,items.Count)]);
    }
}
