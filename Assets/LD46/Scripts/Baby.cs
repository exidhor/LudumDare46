using UnityEngine;
using System.Collections;
using Tools;

public class Baby : MonoSingleton<Baby>
{
    public Vector2 pos2D
    {
        get
        {
            Vector3 pos3D = transform.position;

            return new Vector2(pos3D.x, pos3D.z);
        }
    }

    public Texture front;
    public Texture back;

    public float speed;
    public float arriveRadius;

    public Item target;

    public void Update()
    {
        Move();
    }

    void Move()
    {
        if(target == null)
        {
            FindTarget();
        }

        if(target != null)
        {
            MoveToTarget();
        }
    }

    void FindTarget()
    {
        target = World.instance.GetRandom();
    }

    void MoveToTarget()
    {
        Vector2 delta = target.pos2D - pos2D;
        delta.Normalize();

        Vector2 velocity = delta * speed * Time.deltaTime;

        Move(velocity);

        if(Vector2.Distance(pos2D, target.pos2D) < arriveRadius)
        {
            target.Remove();
            target = null;
            ItemSpawnerManager.instance.Spawn();
        }

    }

    public void ForceChangeTarget(Item item)
    {
        if(target == item)
        {
            FindTarget();
        }
    }

    void Move(Vector2 move)
    {
        Vector3 move3D = new Vector3(move.x, 0, move.y);
        transform.position = transform.position + move3D;
    }
}
