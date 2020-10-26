using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class handles the collider feet for the player character object.
/// this is to help when the player hits the ground
/// Further implementation to stop the player from jumping into objects and hovering
/// code coppied from online totorial from https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// no true modification was made for prototype 1
/// </summary>
public class FeetCtrl : MonoBehaviour
{
    MainCharacterManager player;

    private void Start()
    {
        player = gameObject.transform.parent.gameObject.GetComponent<MainCharacterManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GROUND")|| collision.gameObject.CompareTag("Falling"))
        {
            player.jumping = false;
        }
    }
}
