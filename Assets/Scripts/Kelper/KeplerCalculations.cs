using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeplersCalculations
{

    //Using Newton Raphson Method
    //https://space.stackexchange.com/questions/55356/how-to-find-eccentric-anomaly-by-mean-anomaly
    //https://en.wikipedia.org/wiki/Newton%27s_method
    public static float ReturnEccentricAnomaly(float meanAnomaly, float eccentricity)
    {
        float accuracy = 0.000001f;
        int tries = 100;

        float eccentricAnomaly;
        if (eccentricity > 0.9f) 
        {
            eccentricAnomaly =  Mathf.PI;
        }
        else
        {
            eccentricAnomaly =  meanAnomaly;
        }


        for(int i = 1; i < tries; i++) 
        {
            float nextGuess = eccentricAnomaly - (KelperEquation(meanAnomaly, eccentricAnomaly, eccentricity) / KelperEquationDifferentiated(eccentricAnomaly, eccentricity));
            float difference = Mathf.Abs(eccentricAnomaly - nextGuess);
            
            eccentricAnomaly = nextGuess;

            if(difference < accuracy)
            {
                break;
            }
        }

        return eccentricAnomaly;
    }


    //Calculate the points in the orbit
    public static Vector3 CalculateKelperOrbit(float apoApsis, float periApsis,float argumentOfPeriapsis, float t)
    {
        float semiMajorAxis = (apoApsis + periApsis) / 2f;
        float semiMinorAxis = Mathf.Sqrt(apoApsis * periApsis);

        float meanAnomaly = t * Mathf.PI * 2f;
        float linearEccentricity = semiMajorAxis - periApsis; // or Mathf.Sqrt(Mathf.Pow(semiMajorAxis,2) - Mathf.Pow(semiMinorAxis,2))
        float eccentricity = linearEccentricity / semiMajorAxis;


        float eccentricAnomaly = ReturnEccentricAnomaly(meanAnomaly, eccentricity);



        float x = semiMajorAxis * (Mathf.Cos(eccentricAnomaly) - eccentricity);
        float y = semiMinorAxis * Mathf.Sin(eccentricAnomaly);

        Quaternion parametricAngle = Quaternion.AngleAxis(argumentOfPeriapsis, Vector3.up);
        return  parametricAngle * new Vector3(x, 0f, y);
    }

    
    //Using Newton method to guess the Value of E (Eccentric Anomaly)
    // M = E - e Sin(E) ---> E - e Sin(E) - M =~ 0
    private static float KelperEquation(float meanAnomaly, float eccentricAnomaly, float eccentric)
    {       
        return eccentricAnomaly - (eccentric * Mathf.Sin(eccentricAnomaly)) - meanAnomaly;
    }


    //Differentation of kelper's equation ---> m = E * e Sin(E)
    private static float KelperEquationDifferentiated(float eccentricAnomaly, float eccentric)
    {
        return 1f - (eccentric * Mathf.Cos(eccentricAnomaly));
    }
}