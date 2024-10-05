using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebtonScript : MonoBehaviour
{
    public PopUpScript popUpScript;
    private void OnMouseEnter()
    {
        popUpScript.ShowPopUp(new Assets.ObjectDetails
        {
            RealImage = Resources.Load<Sprite>("Images/earth.jpg"),
            Name = "Neptune",
            Description = "Bla Bla Bla",
            OrbitPeriod = 60182.0,
            PeriodOfDay = 16,
            radius = 2000000,
            Type = "Planet"
        });
    }

    private void OnMouseExit()
    {
        popUpScript.HidePopUp();
    }
}
