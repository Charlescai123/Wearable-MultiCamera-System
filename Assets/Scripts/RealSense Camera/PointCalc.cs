using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCalc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var lineRenderer = this.gameObject.AddComponent<LineRenderer>();
        //lineRenderer = this GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
        //LineRenderer linerenderer = new LineRenderer<>;
        //linerenderer.SetColors(Color.red, Color.red);
        lineRenderer.SetPosition(0, new Vector3(5, 5, 0));
        lineRenderer.SetPosition(1, new Vector3(5, 5, 1));

        Debug.Log(CalcIntersectPoint(lineRenderer));
    }

    Vector3 CalcIntersectPoint(LineRenderer linerenderer)
    {
        Transform planeTrans = this.gameObject.transform;
        Debug.Log("The transform of mesh is:" + planeTrans.position);
        Vector3 p1 = linerenderer.GetPosition(0);
        Vector3 p2 = linerenderer.GetPosition(1);

        Debug.Log("P1 position is:" + p1);
        Debug.Log("P2 position is:" + p2);


        Vector3 direction = p2 - p1;

        Debug.Log("Direction position is:" + direction);

        
        //Vector3 n = plane.normal;
        //planeTrans.forward
        Vector3 p_0 = planeTrans.position;
        //a normal (defining the orientation of the plane), should be negative if we are firing the ray from above
        Vector3 n = -planeTrans.forward;
        Debug.Log("The normal of mesh is:" + planeTrans.forward);
        //We are intrerested in calculating a point in this plane called p
        //The vector between p and p0 and the normal is always perpendicular: (p - p_0) . n = 0

        //A ray to point p can be defined as: l_0 + l * t = p, where:
        //the origin of the ray

        Vector3 l_0 = p1;
        //l is the direction of the ray

        Vector3 l = direction;
        //t is the length of the ray, which we can get by combining the above equations:
        //t = ((p_0 - l_0) . n) / (l . n)

        //But there's a chance that the line doesn't intersect with the plane, and we can check this by first
        //calculating the denominator and see if it's not small. 
        //We are also checking that the denominator is positive or we are looking in the opposite direction
        float denominator = Vector3.Dot(l, n);

        float t = Vector3.Dot(p_0 - l_0, n) / denominator;

        Debug.Log("The t is:" + t);

        //Where the ray intersects with a plane
        Vector3 p = l_0 + l * t;
        return p;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
