using UnityEngine;
using System.Collections.Generic;
using Tools;

public class ItemSpawnerManager : MonoSingleton<ItemSpawnerManager>
{
    public List<ItemSpawner> spawners;
    public int startSpawn = 5;

    public void Start()
    {
        for(int i = 0; i < startSpawn; i++)
        {
            Spawn();
        }
    }

    public bool Spawn()
    {
        int available = 0;

        for(int i = 0; i < spawners.Count; i++)
        {
            if (spawners[i].item == null) available++;
        }

        if (available == 0) return false;

        int rand = UnityEngine.Random.Range(0, available);

        int current = -1;

        for (int i = 0; i < spawners.Count; i++)
        {
            if (spawners[i].item == null) current++;

            if(current == rand)
            {
                Debug.Log("Current = " + current);

                spawners[i].Spawn(ItemLibrary.instance.GetItem());

                return true;
            }
        }
        return false;
    }
}
