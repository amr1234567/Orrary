using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JubeterScript : MonoBehaviour
{
    public PopUpScript popUpScript;
    private void OnMouseEnter()
    {
        popUpScript.ShowPopUp(new Assets.ObjectDetails
        {
            RealImage = Resources.Load<Sprite>("Images/earth.jpg"),
            Name = "Jupiter",
            Description = "Bla Bla Bla",
            OrbitPeriod = 4332.59,
            PeriodOfDay = 10,
            radius = 2000000,
            Type = "Planet"
        });
    }

    private void OnMouseExit()
    {
        popUpScript.HidePopUp();
    }
}
