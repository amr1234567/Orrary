using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpForSunScript : MonoBehaviour
{
    public PopUpScript popUpScript;
    private void OnMouseEnter()
    {
        popUpScript.ShowPopUp(new Assets.ObjectDetails
        {
            RealImage = Resources.Load<Sprite>("Images/earth.jpg"),
            Name = "Sun",
            Description = "Bla Bla Bla",
            OrbitPeriod = 99999,
            PeriodOfDay = 0,
            radius = 2000000,
            Type = "Star"
        });
    }

    private void OnMouseExit()
    {
        popUpScript.HidePopUp();
    }
}
