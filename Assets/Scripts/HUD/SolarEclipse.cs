using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarEclipse : MonoBehaviour
{
    // Start is called before the first frame update
    public KeplerCelestial earth;
    public KeplerCelestial moon;
    public int question = -1;

    float currSet;
    private float time;

    private GameHUD gameHUD;


    void Awake()
    {
        if(earth == null)
        {
            if(GameObject.Find("Earth"))    
                earth = GameObject.Find("Earth").GetComponent<KeplerCelestial>();
        }
            

        if(moon == null)
            if(GameObject.Find("Moon"))
                moon = GameObject.Find("Moon").GetComponent<KeplerCelestial>();
    }

    private void Start()
    {

        question = DialogueManager.questionNum;
        currSet = GlobalTime.TickRate;

        gameHUD = GetComponent<GameHUD>();
    }

    void Update()
    {
        if(!GameObject.Find("Earth"))
        {
            return;
        }
        else
        {
            earth = GameObject.Find("Earth").GetComponent<KeplerCelestial>();
        }

        if(!GameObject.Find("Moon"))
        {
            return;
        }
        else
        {
            moon = GameObject.Find("Moon").GetComponent<KeplerCelestial>();
        }

        UpdateQuestion();
    }


    private void UpdateQuestion()
    {
        question = DialogueManager.questionNum;
        switch (question)
        {
            //Solar Eclipse
            case 2:
                {
                    //earth.transform.position = new Vector3(1471f,0f,0f);
                    //moon.transform.position = new Vector3(1435f, 0f,0f);

                    Vector3 startPoint = KeplersCalculations.CalculateKelperOrbit(earth.ApoApsis, earth.PeriApsis, earth.ArgumentOfPerapsis, 0f) + earth.Parent.transform.position;
                    Vector3 moonPoint = KeplersCalculations.CalculateKelperOrbit(moon.ApoApsis, moon.PeriApsis, moon.ArgumentOfPerapsis, 180f) + moon.Parent.transform.position;


                    if (earth.transform.position != startPoint)
                    {
                        //earth.transform.position = startPoint;
                        earth.orbitalProgress = 0f;
                        GlobalTime.SetTickRate(0f);
                        gameHUD.timestepSlider.value = 5f;
                        
                    }
                    if(moon.transform.position != moonPoint)
                    {
                        //moon.transform.position = moonPoint;
                        moon.orbitalProgress = 180f;
                    }
                    break;
                }

            //Lunar eclipse
            case 4:
                {
                    Vector3 startPoint = KeplersCalculations.CalculateKelperOrbit(earth.ApoApsis, earth.PeriApsis, earth.ArgumentOfPerapsis, 0f) + earth.Parent.transform.position;
                    Vector3 moonPoint = KeplersCalculations.CalculateKelperOrbit(moon.ApoApsis, moon.PeriApsis, moon.ArgumentOfPerapsis, 0f) + moon.Parent.transform.position;



                    if (earth.transform.position != startPoint)
                    {
                        //earth.transform.position = startPoint;
                        earth.orbitalProgress = 0f;
                        GlobalTime.SetTickRate(0f);
                        gameHUD.timestepSlider.value = 5f;

                    }
                    if (moon.transform.position != moonPoint)
                    {
                        //moon.transform.position = moonPoint;
                        moon.orbitalProgress = 0f;
                    }
                    break;
                }


            case 6:
                {
                    Vector3 startPoint = KeplersCalculations.CalculateKelperOrbit(earth.ApoApsis, earth.PeriApsis, earth.ArgumentOfPerapsis, 0f) + earth.Parent.transform.position;
                    Vector3 moonPoint = KeplersCalculations.CalculateKelperOrbit(moon.ApoApsis, moon.PeriApsis, moon.ArgumentOfPerapsis, 180f) + moon.Parent.transform.position;


                    time += Time.deltaTime;

                    Debug.Log(time);
                    if (earth.transform.position != startPoint)
                    {
                        earth.orbitalProgress = 0f;
                        GlobalTime.SetTickRate(0f);
                        gameHUD.timestepSlider.value = 5f;

                    }
                    if (moon.transform.position != moonPoint)
                    {
                        moon.orbitalProgress = 180f;
                    }

                    if (time > 2f)
                    {
                        //startPoint = KeplersCalculations.CalculateKelperOrbit(earth.ApoApsis, earth.PeriApsis, earth.ArgumentOfPerapsis, 180f) + earth.Parent.transform.position;
                        //moonPoint = KeplersCalculations.CalculateKelperOrbit(moon.ApoApsis, moon.PeriApsis, moon.ArgumentOfPerapsis, 0f) + moon.Parent.transform.position;

                        earth.orbitalProgress = 180f;
                        moon.orbitalProgress = 0f;

                        if(time > 4)
                            time = 0;
                    }

                    break;
                }
        }
    }
}
