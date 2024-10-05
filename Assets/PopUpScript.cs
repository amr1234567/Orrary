using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpScript : MonoBehaviour
{
    public GameObject PopUpWindow;
    public Text NameText;
    public Text DescriptionText;
    public Text OrbitPeriodText;
    public Text TimeOfDayText;
    public Text RaduisText;
    public Text TypeText;
    public Image Image;
    public void ShowPopUp(ObjectDetails objectDetails)
    {
        PopUpWindow.SetActive(true);
        NameText.text = $"{objectDetails.Name}";
        DescriptionText.text = $"Description: {objectDetails.Description}";
        OrbitPeriodText.text = $"Orbit period (in earth time): {objectDetails.OrbitPeriod} days";
        TimeOfDayText.text = $"Time Of Dat (in earth time):  {objectDetails.PeriodOfDay} hours";
        RaduisText.text = $"Raduis (in meter):            {objectDetails.radius}      M";
        TypeText.text = $"Type: {objectDetails.Type}";
        Image.sprite = objectDetails.RealImage;
    }
    public void HidePopUp()
    {
        PopUpWindow.SetActive(false);
    }
}
