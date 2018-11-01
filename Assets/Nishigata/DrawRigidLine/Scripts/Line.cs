using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lr;
    private List<Vector2> pointList;

    public void LineUpdate(Vector2 mousePos)
    {
        if (pointList == null)
        {
            pointList = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }

        if (Vector2.Distance(pointList.Last(), mousePos) > 0.1f)
        {
            SetPoint(mousePos);
        }
    }

    private void SetPoint(Vector2 point)
    {
        pointList.Add(point);

        lr.positionCount = pointList.Count;
        lr.SetPosition(pointList.Count - 1, point);
    }
}