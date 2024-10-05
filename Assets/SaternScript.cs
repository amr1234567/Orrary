using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaternScript : MonoBehaviour
{
    public PopUpScript popUpScript;
    private void OnMouseEnter()
    {
        popUpScript.ShowPopUp(new Assets.ObjectDetails
        {
            RealImage = Resources.Load<Sprite>("Images/earth.jpg"),
            Name = "Saturn",
            Description = "Bla Bla Bla",
            OrbitPeriod = 10759.22,
            PeriodOfDay = 11,
            radius = 2000000,
            Type = "Planet"
        });
    }

    private void OnMouseExit()
    {
        popUpScript.HidePopUp();
    }
}
