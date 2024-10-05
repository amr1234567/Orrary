using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OranosScript : MonoBehaviour
{
    public PopUpScript popUpScript;
    private void OnMouseEnter()
    {
        popUpScript.ShowPopUp(new Assets.ObjectDetails
        {
            RealImage = Resources.Load<Sprite>("Images/earth.jpg"),
            Name = "Uranus",
            Description = "Bla Bla Bla",
            OrbitPeriod = 30688.5,
            PeriodOfDay = 17,
            radius = 2000000,
            Type = "Planet"
        });
    }

    private void OnMouseExit()
    {
        popUpScript.HidePopUp();
    }
}
