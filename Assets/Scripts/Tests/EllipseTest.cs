using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[RequireComponent (typeof(LineRenderer))]
public class EllipseTest : MonoBehaviour
{
    [SerializeField]
    private float semiMajorAxis = 1f;
    [SerializeField]
    private float semiMinorAxis = 1f;
    [SerializeField]
    private int resolution = 1000;
    [SerializeField]
    private float width = 1f;
    [SerializeField]
    private float rotationAngle = 45;
    [SerializeField]
    private Color color = Color.white;


    /*
    the eccentricity of a conic section is a non-negative real number that uniquely characterizes its shape.

    The eccentricity of a circle is 0.
    The eccentricity of an ellipse which is not a circle is between 0 and 1
    The eccentricity of a parabola is 1

    */
    private float eccentricity = 1f;


    //Position of Foci 1 --> (h + a)e, k) where h is the x coordinate of center of ellipse, a is semiMajor, e is eccentricity, k is y position of center of ellipse
    //Position of Foci 2 --> ((h - a)e, k)
    private Vector3 foci1, foci2;

    //private Vector3[] points;
    private LineRenderer lineRenderer;


    private void Start()
    {
         if(!lineRenderer)
         {
            lineRenderer = GetComponent<LineRenderer>();
         }

        //Eccentricity equation --> sqrt(1 - b^2 / a^2)
        eccentricity = Mathf.Sqrt(1f - Mathf.Pow(semiMinorAxis, 2f) / Mathf.Pow(semiMajorAxis, 2f));

        foci1 = new Vector3(0, 0, (0 + semiMajorAxis) * eccentricity);
        foci2 = new Vector3(0, 0, (0 - semiMajorAxis) * eccentricity);
    }



    private void OnValidate()
    {
        UpdateLinerRenderer();
        UpdateEllipse();
    }


    private void Update()
    {
        eccentricity = Mathf.Sqrt(1f - Mathf.Pow(semiMinorAxis, 2f) / Mathf.Pow(semiMajorAxis, 2f)); // or sqrt(semiMajor^2 - semiMinor^2) / semiMajor
        foci1 = new Vector3(0, 0, (0 + semiMajorAxis) * eccentricity); // or   +sqrt(semiMajor^2 - semiMinor^2)
        foci2 = new Vector3(0, 0, (0 - semiMajorAxis) * eccentricity); // or   -sqrt(semiMajor^2 - semiMinor^2)


        //Debug.Log(foci1 + " " + foci2);
    }

    public void UpdateLinerRenderer()
    {   
        lineRenderer.positionCount = resolution + 3;
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        lineRenderer.sharedMaterial = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));

    }


    public void UpdateEllipse()
    {
        AddPointToLineRenderer(0f,0);

        for (int i = 1; i <= resolution + 1; i++) 
		{
			AddPointToLineRenderer((float)i / (float)(resolution) * 2.0f * Mathf.PI, i);
		}
		AddPointToLineRenderer(0f, resolution + 2);
    }


    void AddPointToLineRenderer(float angle, int index)
	{
		Quaternion pointQuaternion = Quaternion.AngleAxis (rotationAngle, Vector3.forward);
		Vector3 pointPosition;

        //Vector3 radius = new Vector3(semiMinorAxis,0,semiMajorAxis);
		
		pointPosition = new Vector3(semiMinorAxis * Mathf.Sin (angle), 0f , semiMajorAxis * Mathf.Cos (angle));
		pointPosition = pointQuaternion * pointPosition;
		
		lineRenderer.SetPosition(index, pointPosition);		
	}
}