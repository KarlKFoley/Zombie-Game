using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHeadCtrl : MonoBehaviour
{
    Zombie_1Ctrl Zombie;
    // Start is called before the first frame update
    void Start()
    {
        Zombie = gameObject.transform.parent.gameObject.GetComponent<Zombie_1Ctrl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Falling"))
        {
            Zombie.ZombieDeath();
        }
    }
}
