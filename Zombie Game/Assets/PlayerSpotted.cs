using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpotted : MonoBehaviour
{
    public Zombie_1Ctrl zombie;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(zombie.playerSpotted);
            switch (collision.gameObject.tag)
            {
                case "Player":
                    if (!zombie.dead)
                    {
                        Vector2 temp = transform.position;
                        temp.x = temp.x - collision.gameObject.transform.position.x;
                        zombie.playerSpotted = true;
                        zombie.FlipOnEdge(temp.x);
                    }
                    break;
            }
        }
    }
}
