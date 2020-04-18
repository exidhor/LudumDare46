using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour
{
    public Item item
    {
        get { return _item; }
    }

    [SerializeField] Item _item;

    public void Spawn(Item item)
    {
        _item = item;

        World.instance.Register(item);
        _item.SetSpawner(this);
        _item.transform.position = transform.position;
        _item.transform.SetParent(transform);
        _item.gameObject.SetActive(true);
    }

    public void RemoveItem()
    {
        World.instance.Unregister(_item);
        Destroy(_item.gameObject);
        _item = null;
    }
}
