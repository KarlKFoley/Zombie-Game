using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFeetCtrl : MonoBehaviour
{
    JumpingZombie zombie;

    private void Start()
    {
        zombie = gameObject.transform.parent.gameObject.GetComponent<JumpingZombie>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GROUND") || collision.gameObject.CompareTag("Falling"))
        {
            zombie.jumping = false;
            zombie.hittheGround();
        }
    }
}
