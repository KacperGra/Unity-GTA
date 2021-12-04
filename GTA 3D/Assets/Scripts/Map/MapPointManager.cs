using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPointManager : MonoBehaviour
{
    private List<MapPoint> _mapPointList;

    private void Awake()
    {
        _mapPointList = new List<MapPoint>();
        foreach (Transform child in transform)
        {
            var mapPoint = child.GetComponent<MapPoint>();
            if (mapPoint != null)
            {
                _mapPointList.Add(mapPoint);
            }
        }
    }

    public Transform GetNextPoint(Transform currentPoint)
    {
        foreach (MapPoint point in _mapPointList)
        {
            if (currentPoint.position == point.transform.position)
            {
                return point.GetNextPoint;
            }
        }

        return null;
    }

    public Transform GetNearestPoint(Transform currentPosition)
    {
        Transform nearestPoint = _mapPointList[0].transform;
        float nearestDistance = Vector3.Distance(currentPosition.position, nearestPoint.position);

        for (int i = 1; i < _mapPointList.Count; ++i)
        {
            var point = _mapPointList[i];
            float distance = Vector3.Distance(currentPosition.position, point.transform.position);

            if (distance < nearestDistance)
            {
                nearestPoint = point.transform;
                nearestDistance = distance;
            }
        }

        return nearestPoint;
    }
}