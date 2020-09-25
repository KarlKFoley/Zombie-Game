using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// This Script is to control a bullet once it is fired
/// Handles a bullet and how it interacts with objects in comes into contact with.
/// below code came from online tutorial https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// Modifcations listed below
/// </summary> 
public class BulletCtrl : MonoBehaviour
{

    public Vector2 speed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed;
    }

    /// <summary>
    /// Declaration is from above listed totorial
    /// changed the mutiple if statements to a switch statments
    /// At the moment all of these are destroy the bullet object.
    /// removed handling of how it affects other object to their Collision detection
    /// this was to stop double handing in classes
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {

            case "Player":
                Destroy(gameObject);
                break;
            case "Enemy":
                Destroy(gameObject);
                break;
            case "Create": ///Current object is not in playable prototype - will be implemented in second prototype
                Destroy(gameObject);
                break;
            case "GROUND":
                Destroy(gameObject);
                break;
        }
    }
}

