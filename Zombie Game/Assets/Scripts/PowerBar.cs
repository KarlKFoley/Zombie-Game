using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Class handles the power bar.
/// Implementation is code is from tutorial https://www.youtube.com/watch?v=BLfNP4Sc_iA
/// Modication to suit project
/// </summary>
public class PowerBar : MonoBehaviour
{
    public Slider slider;

    public void SetUpPower(int MaxPower, int startingPower)
    {
        slider.maxValue = MaxPower;
        slider.value = startingPower;
    }
    public void SetPower(int power)
    {
        slider.value = power;
    }
}
