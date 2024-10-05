using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour
{
    public PopUpScript popUpScript;
    public CameraPosition cam;
    public bool Clicked;
    private void OnMouseEnter()
    {
        popUpScript.ShowPopUp(new Assets.ObjectDetails
        {
            RealImage = Resources.Load<Sprite>("Images/earth.jpg"),
            Name = "Earth",
            Description = "Bla Bla Bla",
            OrbitPeriod = 365.25638,
            PeriodOfDay = 24,
            radius = 2000000,
            Type = "Star"
        });
    }

    private void OnMouseExit()
    {
        popUpScript.HidePopUp();
    }

    private void OnMouseDown()
    {
       if(Input.GetMouseButtonDown(0))
        {
            cam.Trigger(transform.position);
        }
    }
}
