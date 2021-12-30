using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_test : MonoBehaviour
{

    private int count = 0;

    public int x = 0;
    public int y = 0;
    public int z = 0;


    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        var p1 = new Vector3(0, 1, 2);
        var p2 = new Vector3(30, 40, 50);
        var p3 = new Vector3(63, 712, 89);
        var plane = new Plane(p1, p2, p3);
        var meshrenderer = this.gameObject.AddComponent<MeshRenderer>();
        var meshfilter = this.gameObject.AddComponent<MeshFilter>();

        //meshfilter.mesh = Plane;
        meshfilter.sharedMesh = Resources.Load<Mesh>("Assets/Materials/grey_tile.mat");
        
        Debug.Log("The mesh is:" + meshfilter.sharedMesh);
        //meshrenderer.materials = 

    }

    // Update is called once per frame
    void Update()
    {

        //For creating line renderer object
        lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;


        x = count;
        y = count;
        z = count;

        Debug.Log("The count is:" + count);
        //For drawing line in the world space, provide the x,y,z values
        lineRenderer.SetPosition(0, new Vector3(x, y, z)); //x,y and z position of the starting point of the line
        lineRenderer.SetPosition(1, new Vector3(count + 40, count - 5000, count + 60)); //x,y and z position of the end point of the line

        count++;

        //Destroy(lineRenderer);

    }
}
