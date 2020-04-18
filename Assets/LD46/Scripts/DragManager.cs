using UnityEngine;
using System.Collections;

public class DragManager : MonoBehaviour
{
    public int layerItem;
    public int layerGround;

    public Item _dragging;
    public Vector2 delta;

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }

    Item Find()
    {
        RaycastHit[] hits;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hits = Physics.RaycastAll(ray.origin, ray.direction, 1000f, LayerMask.GetMask("Item"));
        if (hits.Length > 0)
        {
            float bestDistance = float.MaxValue;
            int best = -1;

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].distance < bestDistance)
                {
                    bestDistance = hits[i].distance;
                    best = i;
                }
            }

            Item item = hits[best].transform.parent.GetComponent<Item>();

            return item;
        }

        return null;
    }

    void HandleInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _dragging = Find();

            if(_dragging != null)
            {
                _dragging.StartDragging(delta);
                Baby.instance.ForceChangeTarget(_dragging);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_dragging != null)
            {
                _dragging.StopDragging();
                _dragging = null;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (_dragging != null)
            {
                Move();
            }
        }
    }

    void Move()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Ground"));

        _dragging.SetPos2D(new Vector2(hit.point.x, hit.point.z));
    }
}
