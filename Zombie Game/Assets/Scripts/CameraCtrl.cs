using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class controls the camera to follow the player
/// understanding of implemtation can from tutorial https://www.youtube.com/watch?v=ula1o_ZsMU0
/// The camera is clamped to the edges of which the player can operate.
/// This clamp lines up with the invisible walls
/// </summary>
public class CameraCtrl : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x,-0.5f, 50.4f), Mathf.Clamp(player.position.y, 1.9f, 10.15f),-10);
    }
}
