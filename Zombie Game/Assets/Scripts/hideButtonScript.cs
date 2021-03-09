using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideButtonScript : MonoBehaviour
{
    public GameObject mute;
    public GameObject volumeControl;
    private bool active;

    void Awake()
    {
        active = false;
        mute.gameObject.SetActive(false);
        volumeControl.gameObject.SetActive(false);
    }
    public void hidepanel()
    {
        mute.gameObject.SetActive(!active);
        volumeControl.gameObject.SetActive(!active);
        active = !active;
    }
}
