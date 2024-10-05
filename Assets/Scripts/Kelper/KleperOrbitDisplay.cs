using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[RequireComponent (typeof(LineRenderer))]
public class KeplerOrbit : MonoBehaviour
{
    [SerializeField]
    private int resolution = 1000;
    [SerializeField]
    private float width = 2f;
    [SerializeField]
    private Color color = Color.white;


    private KeplerCelestial body;
    public LineRenderer lineRenderer;

    private void Awake()
    {
        if(!lineRenderer)
            lineRenderer = GetComponent<LineRenderer>();

        body = GetComponent<KeplerCelestial> ();
        lineRenderer.sharedMaterial = new Material(Shader.Find("Particles/Standard Unlit"));
        lineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;   
        lineRenderer.receiveShadows = false;
    }


    private void Update()
    { 
        UpdateLinerRenderer();
        Draw();
    }


    public void UpdateLinerRenderer()
    {   
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }

    private void Draw()
    { 
        lineRenderer.positionCount = resolution;
        for(int i = 0; i < resolution; i++)
        {
            Vector3 point = KeplersCalculations.CalculateKelperOrbit(body.ApoApsis,body.PeriApsis,body.ArgumentOfPerapsis, (float)i / (float)resolution * Mathf.PI); //(float)i / (float)resolution * 2f * Mathf.PI
            point += body.Parent.transform.position;
            lineRenderer.SetPosition(i, point);
        }
	}
}