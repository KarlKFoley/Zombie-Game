using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Controls a volume slider based of the overall volume of the game
/// </summary>
public class UpdateSlider : MonoBehaviour
{
    public Slider slider;
  

    // Update is called once per frame
    void Update()
    {
        slider.value = OverAllGameInfo.volume;
    }
}
