using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;
///<summary>
/// This Script stores variables that are used for the UI in an instance of Gamectrl
/// below code came from online tutorial https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// Modifcation of variable names to suit project
/// </summary> 

[Serializable]
public class UI
{
    [Header("Text")]
    public Text Civilians_rescued;
    public Text Kill_Bonus;
    public Text Timer;

    [Header("Images/Sprits")]
    public Image shield0;
    public Image shield1;
    public Image shield2;
    public Image shield3;

    public GameObject GameOver;
    public GameObject LevelComplete;
}
