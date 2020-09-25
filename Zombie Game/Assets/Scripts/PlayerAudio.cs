using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


///<summary>
/// This Script stores variables that are used for the Audio playing
/// below code came from online tutorial https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// Modifcation of variable names to suit project
/// </summary>
[Serializable]
public class PlayerAudio
{
    public AudioClip playerShoots;
    public AudioClip playerjumps;
    public AudioClip zombieSound; // current not implemented in game - selected clip to long and not right implementation, caused a white noise effect that caused issues 
}

