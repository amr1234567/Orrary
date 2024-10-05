using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    public TextMeshProUGUI year;
    public TextMeshProUGUI month;
    public TextMeshProUGUI day;
    public Slider timestepSlider;
    public TextMeshProUGUI timeStepText;

    public void Update()
    {
        if(Application.isPlaying)
            UpdateTimeStepGUI();
    }


    private void UpdateTimeStepGUI()
    {
        int timestepValue = (int)(timestepSlider.value - (timestepSlider.maxValue / 2f));
        timeStepText.text = timestepValue == 0 ? "RT" : timestepValue.ToString();

        float percent = Mathf.Abs(timestepValue) / (timestepSlider.maxValue / 2f);
        float scalar = 20000000 * percent / 20f;
        GlobalTime.SetTickRate(timestepValue == 0 ? 1 : timestepValue * scalar);



        year.text = "Years : " + GlobalTime.Year.ToString("F0");

        int Month = (int)(GlobalTime.Day / 30.42f);
        month.text = "Months : " + Month.ToString("F0"); ;

        int Day = (int)(GlobalTime.Day % 30.42f);
        day.text = "Days : " + Day.ToString("F0");
    }


}