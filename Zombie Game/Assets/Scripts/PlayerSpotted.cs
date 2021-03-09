using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpotted : MonoBehaviour
{
    public Zombie zombie;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (collision.gameObject.tag)
            {
                case "Player":
                    if (!zombie.dead)
                    {
                        zombie.playerFound = true;
                        zombie.playerSpotted = true;
                        zombie.FlipOnEdge();
                    }
                    break;
            }
        }
    }
}
