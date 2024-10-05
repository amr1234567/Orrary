using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CreatePlanetManager : MonoBehaviour
{
    public Button create;
    public GameObject radiusHandler;
    public GameObject argumentOfPerapsisHandler;

    public TMP_InputField bodyName;
    public TMP_InputField parentName;
    public TMP_InputField apoapsisValue;
    public TMP_InputField periapsisValue;
    public TMP_InputField axialTilt;
    public TMP_InputField orbitalPeriod;
    public TMP_InputField rotationPeriod;
    public TMP_InputField select;
    public TMP_Dropdown bodyType;
    public Toggle draw;
    public Button done;
    public Button delete;




    private Slider radiusSlider;
    private TextMeshProUGUI radiusText;
    private Slider argumentOfPerapsisSlider;
    private TextMeshProUGUI argumentOfPerapsisText;


    private GameObject planet;
    private KeplerCelestial planetDetails;
    private KeplerOrbit planetOrbitDraw;


    private string bodyNameS;
    private string parentNameS;
    private string apoapsisValueS;
    private string periapsisValueS;
    private string axialTiltS;
    private string orbitalPeriodS;
    private string rotationPeriodS;
    private string radiusS;
    private string argumentS;
    private string selectS;


    public Material earthMat;
    public Material moonMat;

    public void Awake()
    {

        radiusSlider = radiusHandler.GetComponentInChildren<Slider>();
        radiusText = radiusHandler.GetComponentInChildren<TextMeshProUGUI>();

        argumentOfPerapsisSlider = argumentOfPerapsisHandler.GetComponentInChildren<Slider>();
        argumentOfPerapsisText = argumentOfPerapsisHandler.GetComponentInChildren<TextMeshProUGUI>();


        bodyNameS = bodyName.text;
        parentNameS = parentName.text;
        apoapsisValueS = apoapsisValue.text;
        periapsisValueS = periapsisValue.text;
        axialTiltS = axialTilt.text;
        orbitalPeriodS = orbitalPeriod.text;
        rotationPeriodS = rotationPeriod.text;
        radiusS = radiusText.text;
        argumentS = argumentOfPerapsisText.text;
        selectS = select.text;


        bodyName.interactable = false;
        parentName.interactable = false;
        apoapsisValue.interactable = false;
        periapsisValue.interactable = false;
        axialTilt.interactable = false;
        orbitalPeriod.interactable = false;
        rotationPeriod.interactable = false;
        bodyType.interactable = false;
        radiusSlider.interactable = false;
        argumentOfPerapsisSlider.interactable = false;
        draw.interactable = false;
        delete.interactable = false;
    }

    public void Start()
    {
        radiusSlider.minValue = 1f;
        radiusSlider.maxValue = 200f;
        

        argumentOfPerapsisSlider.minValue = (int)0;
        argumentOfPerapsisSlider.maxValue = (int)360;


        //bodyType.captionText.textStyle = TMP_Settings.defaultStyleSheet.GetStyle("Title");;
        //bodyType.captionText.text = "Type";
        //Debug.Log(bodyType.options[bodyType.value].text);
    }

    public void CreatePlanet()
    {
        planet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        planet.transform.position = new Vector3(0,0,0);


        planetDetails = planet.AddComponent<KeplerCelestial>();


        if (planet.GetComponent<KeplerOrbit>() == null)
        { 
            planet.AddComponent<KeplerOrbit>().enabled = false;
            planetOrbitDraw = planet.GetComponent<KeplerOrbit>();
            draw.isOn = false;
        }

        create.interactable = false;
        planetDetails.Type = (PlanetType)(bodyType.value);
        done.interactable = true;



        bodyName.interactable = true;
        parentName.interactable = true;
        apoapsisValue.interactable = true;
        periapsisValue.interactable = true;
        axialTilt.interactable = true;
        orbitalPeriod.interactable = true;
        rotationPeriod.interactable = true;
        bodyType.interactable = true;
        radiusSlider.interactable = true;
        argumentOfPerapsisSlider.interactable = true;
        draw.interactable = true;
        delete.interactable = false;

    }


    public void SetRadius()
    {
        radiusText.text = radiusSlider.value.ToString();
        planetDetails.Radius = radiusSlider.value;
    }


    public void SetArgumentOfPeriapsis()
    {
        argumentOfPerapsisText.text = argumentOfPerapsisSlider.value.ToString();
        planetDetails.ArgumentOfPerapsis = argumentOfPerapsisSlider.value;
    }

    public void SetParent()
    {
        if(!GameObject.Find(parentName.text))
        { 
            parentName.text = "Not Found";
            return;
        }

        planetDetails.Parent = GameObject.Find(parentName.text.Trim((char)8203)).GetComponent<KeplerCelestial>();
    }

    public void SetName()
    {
        planetDetails.ObjectName = bodyName.text;

        if(planetDetails.ObjectName == "Moon")
        {
            planetDetails.GetComponent<MeshRenderer>().material = moonMat;
        }

        if (planetDetails.ObjectName == "Earth")
        {
            planetDetails.GetComponent<MeshRenderer>().material = earthMat;
        }


        planetDetails.name = bodyName.text;
    }

    public void SetType()
    {
        planetDetails.Type = (PlanetType)(bodyType.value);
    }


    public void SetApoapsis()
    {
        float apo = 0;

        if(float.TryParse(apoapsisValue.text,out apo))
        {
            planetDetails.ApoApsis = apo;
        }
    }

    public void SetPeriapsis()
    {
        float peri = 0;

        if(float.TryParse(periapsisValue.text,out peri))
        {
            planetDetails.PeriApsis = peri;
        }
    }

    public void SetAxialTilt()
    {
        float axi = 0;

        if(float.TryParse(axialTilt.text,out axi))
        {
            planetDetails.AxialTilt = axi;
        }
    }

    public void SetOrbitalPeriod()
    {
        float x = 0;

        if(float.TryParse(orbitalPeriod.text,out x))
        {
            planetDetails.OrbitalPeriod = x;
        }
    }


    public void SetRotationPeriod()
    {
        float x = 0;

        if(float.TryParse(rotationPeriod.text,out x))
        {
            planetDetails.RotationPeriod = x;
        }
    }

    public void isDrawable()
    {
        if(draw.isOn)
        {
            if (!this.planetOrbitDraw.enabled)
                this.planetOrbitDraw.enabled = true;

            this.planetOrbitDraw.lineRenderer.enabled = true;
        }
        else
        {
            this.planetOrbitDraw.lineRenderer.enabled = false;
        }
    }

    public void Done()
    {
        create.interactable = true;
        done.interactable = false;
        bodyName.text = bodyNameS;
        parentName.text = parentNameS;



        apoapsisValue.text = apoapsisValueS;
        periapsisValue.text = periapsisValueS;
        orbitalPeriod.text = orbitalPeriodS;
        rotationPeriod.text = rotationPeriodS;
        axialTilt.text = axialTiltS;
        radiusText.text = radiusS;
        argumentOfPerapsisText.text = argumentS;



        radiusSlider.SetValueWithoutNotify(1f);
        argumentOfPerapsisSlider.SetValueWithoutNotify(0f);
        bodyType.SetValueWithoutNotify(0);
        draw.SetIsOnWithoutNotify(false);



        bodyName.interactable = false ;
        parentName.interactable = false;
        apoapsisValue.interactable = false;
        periapsisValue.interactable = false;
        axialTilt.interactable = false;
        orbitalPeriod.interactable = false;
        rotationPeriod.interactable = false;
        bodyType.interactable = false;
        radiusSlider.interactable = false;
        argumentOfPerapsisSlider.interactable = false;
        draw.interactable = false;
    }


    public void Select()
    {
        if (!GameObject.Find(select.text))
        {
            select.text = "Not Found";
            return;
        }

        planetDetails = GameObject.Find(select.text.Trim((char)8203)).GetComponent<KeplerCelestial>();
        planetOrbitDraw = GameObject.Find(select.text.Trim((char)8203)).GetComponent<KeplerOrbit>();

        bodyName.text = planetDetails.ObjectName;
        parentName.text = planetDetails.Parent.ObjectName;
        apoapsisValue.text = planetDetails.ApoApsis.ToString();
        periapsisValue.text = planetDetails.PeriApsis.ToString();
        axialTilt.text = planetDetails.AxialTilt.ToString();
        orbitalPeriod.text = planetDetails.OrbitalPeriod.ToString();
        rotationPeriod.text = planetDetails.RotationPeriod.ToString(); ;
        bodyType.value = (int)planetDetails.Type;
        draw.isOn = planetOrbitDraw.lineRenderer.enabled;
        radiusSlider.value = planetDetails.Radius;
        argumentOfPerapsisSlider.value = planetDetails.ArgumentOfPerapsis;


        if (bodyName.interactable == false)
        {
            bodyName.interactable = true;
            parentName.interactable = true;
            apoapsisValue.interactable = true;
            periapsisValue.interactable = true;
            axialTilt.interactable = true;
            orbitalPeriod.interactable = true;
            rotationPeriod.interactable = true;
            bodyType.interactable = true;
            radiusSlider.interactable = true;
            argumentOfPerapsisSlider.interactable = true;
            draw.interactable = true;
            delete.interactable = true;
        }

        select.text = selectS;
    }


    public void Delete()
    {
        planet = planetDetails.gameObject;
        Destroy(planetOrbitDraw);
        Destroy(planetDetails);
        Destroy(planet);


        bodyName.text = bodyNameS;
        parentName.text = parentNameS;
        apoapsisValue.text = apoapsisValueS;
        periapsisValue.text = periapsisValueS;
        orbitalPeriod.text = orbitalPeriodS;
        rotationPeriod.text = rotationPeriodS;
        axialTilt.text = axialTiltS;
        radiusText.text = radiusS;
        argumentOfPerapsisText.text = argumentS;


        bodyName.interactable = false;
        parentName.interactable = false;
        apoapsisValue.interactable = false;
        periapsisValue.interactable = false;
        axialTilt.interactable = false;
        orbitalPeriod.interactable = false;
        rotationPeriod.interactable = false;
        bodyType.interactable = false;
        radiusSlider.interactable = false;
        argumentOfPerapsisSlider.interactable = false;
        draw.interactable = false;
        delete.interactable = false;

        radiusSlider.SetValueWithoutNotify(1f);
        argumentOfPerapsisSlider.SetValueWithoutNotify(0f);
        bodyType.SetValueWithoutNotify(0);
        draw.SetIsOnWithoutNotify(false);
    }
}
