using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class handles any object that will drop from its placed location on it collides
/// currently only used for the balcony object - further implementation to go with moving objects
/// code understanding and implmenation is from https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// </summary>
public class DroppingObject : MonoBehaviour
{
    private Rigidbody2D rb;

    public float droppingDelay;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Feet"))
        {
            Invoke("Drop", droppingDelay);
        }
    }

    private void Drop()
    {
        rb.isKinematic = false;
    }
}
