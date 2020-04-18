using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public Vector2 pos2D
    {
        get
        {
            Vector3 pos3D = transform.position;

            return new Vector2(pos3D.x, pos3D.z);
        }
    }

    ItemSpawner _spawner;

    public void SetSpawner(ItemSpawner spawner)
    {
        _spawner = spawner;
    }

    public void Remove()
    {
        _spawner.RemoveItem();
    }
}
