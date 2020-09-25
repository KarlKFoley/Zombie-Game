using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the special effects
public class SFXCtrl : MonoBehaviour
{
    public static SFXCtrl instance;
    public GameObject sfx_orb_pickup;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    ///<Summary>
    //Shows players has picked up the item
    ///</Summary>
    public void showOrbGlow(Vector3 position)
    {
        Instantiate(sfx_orb_pickup, position, Quaternion.identity);
    }
}
