using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDistance
{
    public Vector3 _direction;
    public float _distance;
    public DirectionDistance(Vector3 direction, float distance)
    {
        this._direction = direction;
        this._distance = distance;
    }
}

public class ClearSight : MonoBehaviour
{
    public float DistanceToPlayer = 5.0f;
    public Transform PlayerPos;


    DirectionDistance getDirectionFromCameraToPlayer()
    {
        Vector3 heading = transform.position - PlayerPos.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;
        return new DirectionDistance(direction, distance);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits;
        Debug.DrawRay(transform.position, transform.forward, Color.green, 20);
        hits = Physics.RaycastAll(transform.position, transform.forward, getDirectionFromCameraToPlayer()._distance);
        Debug.Log(hits.Length.ToString());
        foreach (RaycastHit hit in hits)
        {
            Renderer R = hit.collider.GetComponent<Renderer>();
            if (R == null)
            {
                continue;
            }
            AutoTransparent AT = R.GetComponent<AutoTransparent>();
            if (AT == null)
            {
                continue;
            }
            AT.BeTransparent();
        }
    }
}
