using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercryScript : MonoBehaviour
{
    public PopUpScript popUpScript;
    private void OnMouseEnter()
    {
        popUpScript.ShowPopUp(new Assets.ObjectDetails
        {
            RealImage = Resources.Load<Sprite>("Images/earth.jpg"),
            Name = "Mercury",
            Description = "Bla Bla Bla",
            OrbitPeriod = 88,
            PeriodOfDay = 1408,
            radius = 2000000,
            Type = "Planet"
        });
    }

    private void OnMouseExit()
    {
        popUpScript.HidePopUp();
    }
}
