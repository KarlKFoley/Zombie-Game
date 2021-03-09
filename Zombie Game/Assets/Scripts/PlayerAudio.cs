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
    public AudioClip zombieSound;
    public AudioClip ZombieDeathSound;
    public AudioClip CivilianHelpSound;
    public AudioClip CivilianSaveSound;
    public AudioClip ShieldDamageSound;
    public AudioClip PlayerDies;
    public AudioClip playerWalks;
}

