using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newton : MonoBehaviour
{
    private const float G = 0.0001f;

    [SerializeField]
    private float mass;
    [SerializeField]
    private float radius;
    [SerializeField]
    private Vector3 initialVelocity;
    [SerializeField]
    private Newton parentBody;

    private Vector3 CurrentVelocity;


    public float Mass { get { return mass; } }
    public Vector3 InitialVelocity { get { return initialVelocity; } }
    public Newton ParentBody { get { return parentBody; } }


    private void Awake()
    {
        CurrentVelocity = initialVelocity;
    }

    private void OnValidate()
    {
        CurrentVelocity = initialVelocity;
        transform.localScale = Vector3.one * radius * 2;
    }

    //Newton's Law of Universal Gravitation
    public void Gravity()
    {
        if(!parentBody) return;

        //Calculating the distance between two objects from their centers' --> r^2
        float Distance = (parentBody.transform.position - transform.position).sqrMagnitude;

        //Direction of two bodies
        Vector3 Direction = (parentBody.transform.position - transform.position).normalized;

        //F = G (m1 * m2) / r^2
        Vector3 Force = Direction * G * (mass * parentBody.mass) / Distance;

        CurrentVelocity += Force * 0.1f;

        transform.position += CurrentVelocity;
    }

    private void FixedUpdate()
    {
        Gravity();
    }
}