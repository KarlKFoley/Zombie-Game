using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class destroys an object after it was created
/// Handles removal of a bullet after is spawns
/// below code came from https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// no modification of code
/// </summary>
public class DestroyWithDelay : MonoBehaviour
{

    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delay);
    }
}
