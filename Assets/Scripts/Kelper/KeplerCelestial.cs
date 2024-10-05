using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;



public class KeplerCelestial : MonoBehaviour
{
    [SerializeField]
    private PlanetType type = PlanetType.Planet;
    [SerializeField]
    private string objectName = "body";
    [SerializeField]
    KeplerCelestial parent;
    [SerializeField]
    private float radius = 10f;
    [SerializeField]
    private float apoapsis = 1f;
    [SerializeField]
    private float periapsis = 1f;
    //The place where the Periapsis will be
    [SerializeField][Range(0f,360f)]
    private float argumentOfPeriapsis = 0f;
    [SerializeField]
    private float axialTilt = 0f;



    //time planet takes to rotate the whole orbit
    [SerializeField]
    private float orbitalPeriod = 0f;
    //the time planet takes to full rotate around itself
    [SerializeField]
    private float rotationPeriod = 0f;


    //progress level of Planet rotating around another object
    public float orbitalProgress = 0f;
    //progress level of planet rotating around it's self
    private float rotationProgress = 0f;
    //number of compeleted orbits from the start point (PeriApsis) to end point (periapsis again)
    private int compeletedOrbits;



    public float NormalizedOrbit { get { return orbitalProgress / 365f; } }
    public float NormalizedRotation { get { return rotationProgress / 360f; } }


    public float ApoApsis 
    { 
        get{ return apoapsis;} 
        set{ apoapsis = value;}
    }

    public float PeriApsis 
    {  
        get{ return periapsis;} 
        set { periapsis = value;}
    }

    public float AxialTilt
    {
        get{ return axialTilt;} 
        set { axialTilt = value;}
    }

    public float RotationPeriod
    {
        get{ return rotationPeriod;} 
        set { rotationPeriod = value;}
    }

    public float OrbitalPeriod
    {
        get{ return orbitalPeriod;} 
        set { orbitalPeriod = value;}
    }

    public float Radius
    {
        get { return radius;}
        set { radius = value;}
    }
    public KeplerCelestial Parent 
    { 
        get{ return parent;} 
        set{ parent = value;}
    }

    public PlanetType Type
    {
        get{return type;}
        set{type = value;}
    }

    public float ArgumentOfPerapsis 
    { 
        get{ return argumentOfPeriapsis;} 
        set{ argumentOfPeriapsis = value;}
    }

    public string ObjectName
    {
        get{ return objectName;} 
        set{ objectName = value;}
    }



    private void OnValidate()
    {
        gameObject.name = objectName == string.Empty ? "" : objectName;
        transform.localScale = new Vector3(radius * 2f, radius * 2f, radius * 2f);

        if(type == PlanetType.Star || !parent)
            return;

        apoapsis = Mathf.Max(apoapsis, 0);
        periapsis = Mathf.Max(periapsis, 0);
        OrbitPoints(0);


        //stepsRate = timeRate * timeStepScalar;

        //Time.timeScale = 1f;
    }


    private void FixedUpdate()
    {
        if(type == PlanetType.Star || !parent)
            return;
        

        UpdateData();
        //UpdateTime();
        Progress();    
        OrbitPoints(NormalizedOrbit);
    }


    private void UpdateData()
    {
        transform.localScale = new Vector3(radius * 2f, radius * 2f, radius * 2f);


        apoapsis = Mathf.Max(apoapsis, 0);
        periapsis = Mathf.Max(periapsis, 0);
    }

    private void Progress()
    {
        float orbitStep = (365f / orbitalPeriod) * (GlobalTime.YearTick);
        float rotationStep = (360f / -rotationPeriod) * (GlobalTime.DayTick);


        orbitalProgress += orbitStep;
        orbitalProgress %= 365f; //Reset to 0 when reach to 365

        rotationProgress += rotationStep;
        rotationProgress %= 360f; //Reset to 0 when reach to 360

        compeletedOrbits += (int)(orbitStep/365f);
    }



    public void OrbitPoints(float orbitalProg)
    {
        Vector3 point = KeplersCalculations.CalculateKelperOrbit(apoapsis,periapsis,argumentOfPeriapsis,orbitalProg);

        
        // Sidereal day = time taken for a body to rotate once about its axis, OR, the time taken for 'fixed' stars to appear in the same spot in the sky again
        float siderealDay = rotationProgress * 360f * (type == PlanetType.Moon ? 0f : 1f); // Satellites should be tidally locked, axial rotation should therefore be synced with the orbital period
        
        //Solar day = time taken for the sun to appear in the same spot in the sky (24 hours on earth)
        float solarDay = siderealDay - orbitalProgress * 360f;

        transform.rotation = Quaternion.Euler(0f, 0f, -axialTilt) * Quaternion.Euler(0f, solarDay, 0f);
        transform.position = point + parent.transform.position;
    }
}




















////CalculateTime
//private float stepsRate = 1f;
//[SerializeField]
//private float timeRate = 1f;
//[SerializeField]
//private float timeStepScalar = 200000f;


//private float minute;
//private float hour;
//private float day;
//private float year;

//private float rawMinute;
//private float rawHour;
//private float rawDay;
//private float rawYear;




////Time Simulation because real time numbers are too big 
///* the following are treated as
// * Minutes ---> Seconds
// * Hours ---> Minutes
// * days ---> Hours
// * years ---> days
// */

//public float TimeStep { get { return Time.deltaTime; } }// 1 / numberOfFrames per second ... can be used as seconds https://docs.unity3d.com/ScriptReference/Time-deltaTime.html
//public float MinuteTick { get { return stepsRate * TimeStep; } }
//public float HourTick { get { return (stepsRate / 60f) * TimeStep; } }
//public float DayTick { get { return (stepsRate / (60f * 60f)) * TimeStep; } }
//public float YearTick { get { return (stepsRate / (60f * 60f * 24f)) * TimeStep; } }

//public float Minute { get { return (int)(rawMinute / 60f) % 60f; } }
//public float Hour { get { return (int)(rawHour / 60f) % 24f; } }
//public float Day { get { return (int)(rawDay / 24f) % 365f; } }
//public float Year { get { return (int)(rawYear / 365f); } }




////////Number in Seconds for Real Time
////public float TimeStep { get { return Time.deltaTime; } } // 1 / numberOfFrames per second ... can be used as seconds https://docs.unity3d.com/ScriptReference/Time-deltaTime.html
////public float SecondTick { get { return stepsRate * Time.deltaTime; } } 
////public float MinuteTick { get { return (stepsRate / 60f) * TimeStep; } }
////public float HourTick { get { return (stepsRate / (60f * 60f)) * TimeStep; } }
////public float DayTick { get { return (stepsRate / (60f * 60f * 24f)) * TimeStep; } }
////public float MonthTick { get { return (stepsRate / (60f * 60f * 24f * 30.42f)) * TimeStep; } }
////public float YearTick { get { return (stepsRate / (60f * 60f * 24f * 30.42f * 12f )) * TimeStep; } }


////public float Second { get { return (int)(rawSecond) % 60f; } }
////public float Minute { get { return (int)(rawMinute) % 60f; } }
////public float Hour { get { return (int)(rawHour) % 24f; } }
////public float Day { get { return (int)(rawDay) % 30.42f; } }
////public float Month { get { return (int)(rawMonth) % 12f; } }
////public float Year { get { return (int)(rawYear / 365f); } }

//private void UpdateTime()
//{
//    //Time Simulation because real time number is too big 

//    /* the following are treated as
//     * Minutes ---> Seconds
//     * Hours ---> Minutes
//     * days ---> Hours
//     * years ---> days
//     */

//    minute += MinuteTick;
//    hour += HourTick;
//    day += DayTick;
//    year += YearTick;


//    rawMinute += MinuteTick;
//    rawHour += HourTick;
//    rawDay += DayTick;
//    rawYear += YearTick;


//    minute %= 60f;
//    hour %= 60f;
//    day %= 24f;
//    year %= 365f;
//}

////////////////////////////////////////////////////////////////

