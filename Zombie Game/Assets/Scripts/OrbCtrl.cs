using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class handles the orb object and its affects
/// Code implmentation is from https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// modification to suit project needs
/// </summary>
public class OrbCtrl : MonoBehaviour
{

    /// <summary>
    /// Allows for orbs to have 2 different pick up affects
    /// allows for the SFXctrl to identify which way to display affect
    /// </summary>
    public enum OrbFx
    {
        Vanish,
        Fly // currently not implmented
    }

    public OrbFx orbFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (orbFX == OrbFx.Vanish)
            {
                Destroy(gameObject); // Destroy the Orb
            }
        }
    }
}
