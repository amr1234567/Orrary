using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenuisScript : MonoBehaviour
{
    public PopUpScript popUpScript;
    private void OnMouseEnter()
    {
        popUpScript.ShowPopUp(new Assets.ObjectDetails
        {
            RealImage = Resources.Load<Sprite>("Images/earth.jpg"),
            Name = "Venus",
            Description = "Bla Bla Bla",
            OrbitPeriod = 224.701,
            PeriodOfDay = 5832,
            radius = 20000,
            Type = "Planet"
        });
    }

    private void OnMouseExit()
    {
        popUpScript.HidePopUp();
    }
}
