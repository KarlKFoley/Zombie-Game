using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// Directly copied from https://www.youtube.com/watch?v=QZDw8ycoLRw
/// </summary>
public class VolumeCtrl : MonoBehaviour
{
    private void Update()
    {
        AudioListener.volume = OverAllGameInfo.volume;
    }

    public void SetVolume(float vol)
    {
        OverAllGameInfo.volume = vol;
    }

    public void Mute()
    {
        if (OverAllGameInfo.volume == 0)
        {
            OverAllGameInfo.volume = 1;
        }else
        {
            OverAllGameInfo.volume = 0;
        }
    }

}
