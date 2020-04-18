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
    Vector2 _delta;

    public void SetSpawner(ItemSpawner spawner)
    {
        _spawner = spawner;
    }

    public void Remove()
    {
        if(_spawner != null)
            _spawner.RemoveItem();
    }

    public void StartDragging(Vector2 delta)
    {
        _delta = delta;

        Vector3 pos = transform.position;
        pos.z += _delta.x;
        pos.y += _delta.y;
        transform.position = pos;
        _spawner = null;
        World.instance.Unregister(this);
    }

    public void StopDragging()
    {
        Vector3 pos = transform.position;
        pos.y = 0f;
        //pos.z += _delta.x;
        _delta = Vector2.zero;
        transform.position = pos;
        World.instance.Register(this);
    }

    public void SetPos2D(Vector2 pos2D)
    {
        Vector3 pos = transform.position;
        pos.x = pos2D.x;
        pos.z = pos2D.y + _delta.x;
        transform.position = pos;
    }
}
