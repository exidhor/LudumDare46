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
        if(_spawner != null)
            _spawner.RemoveItem();
    }

    public void StartDragging(float y)
    {
        Vector3 pos = transform.position;
        pos.y = y;
        transform.position = pos;
        _spawner = null;
        World.instance.Unregister(this);
    }

    public void StopDragging()
    {
        Vector3 pos = transform.position;
        pos.y = 0f;
        transform.position = pos;
        World.instance.Register(this);
    }

    public void SetPos2D(Vector2 pos2D)
    {
        Vector3 pos = transform.position;
        pos.x = pos2D.x;
        pos.z = pos2D.y;
        transform.position = pos;
    }
}
