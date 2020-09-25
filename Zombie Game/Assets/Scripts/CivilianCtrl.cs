using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class controls the civilian game objects
/// Further implementation needed - Dieing if a zombie hits them also going to have them call out for help letting player know there are still more civilians
/// going to add a counter for the amount of civilians still not rescued in level
/// </summary>
public class CivilianCtrl : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                Destroy(gameObject); // Destroy the Civilian

        }
    }
}
