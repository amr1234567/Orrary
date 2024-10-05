using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsScript : MonoBehaviour
{
    public PopUpScript popUpScript;
    private void OnMouseEnter()
    {
        popUpScript.ShowPopUp(new Assets.ObjectDetails
        {
            RealImage = Resources.Load<Sprite>("Images/earth.jpg"),
            Name = "Mars",
            Description = "Bla Bla Bla",
            OrbitPeriod = 686.971,
            PeriodOfDay = 25,
            radius = 2000000,
            Type = "Planet"
        });
    }

    private void OnMouseExit()
    {
        popUpScript.HidePopUp();
    }
}
