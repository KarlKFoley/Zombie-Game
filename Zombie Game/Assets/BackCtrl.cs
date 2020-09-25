using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCtrl : MonoBehaviour
{
    MainCharacterManager player;
    private void Start()
    {
        player = gameObject.transform.parent.gameObject.GetComponent<MainCharacterManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            //unknown
        }
    }
}