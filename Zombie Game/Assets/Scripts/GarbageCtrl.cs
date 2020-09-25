using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys game Objects that drop below the floor
/// The player will restart if they have enough resources
/// resources respawn not implemented yet -  part of second prototype
/// </summary>
public class GarbageCtrl : MonoBehaviour
{

    /// <summary>
    /// On date it is locked to follow the camera along the X axis.
    /// This is to stop it from removing objects when the camera follows the charater on the Y axis
    /// </summary>
    private void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -0.5f, 33f), Mathf.Clamp(transform.position.y, -9f, -9f));
    }

    /// <summary>
    /// any Object 
    /// Code from https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
    /// This code has been modified to only handle the player object
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameCtrl.instance.PlayerFellToDeath(collision.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

}
