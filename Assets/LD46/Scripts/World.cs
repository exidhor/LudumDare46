using UnityEngine;
using System.Collections.Generic;
using Tools;

public class World : MonoSingleton<World>
{
    List<Item> _onBoard = new List<Item>();

    public void Register(Item item)
    {
        _onBoard.Add(item);
    }

    public void Unregister(Item item)
    {
        _onBoard.Remove(item);
    }

    public Item GetRandom()
    {
        if (_onBoard.Count == 0) return null;

        return _onBoard[UnityEngine.Random.Range(0, _onBoard.Count)];
    }


}
