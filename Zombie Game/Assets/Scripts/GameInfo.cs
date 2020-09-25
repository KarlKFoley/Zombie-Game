using System;
using System.Collections;
using UnityEngine;
///<summary>
/// This Script stores variables that are used in the instance of Gamectrl
/// below code came from online tutorial https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// Modifcation of variable names to suit project and changed to a static class so that it can be accessed by all scenes.
/// use of static class came from https://gamedev.stackexchange.com/questions/110958/what-is-the-proper-way-to-handle-data-between-scenes
/// for further implematation this class will be used to track the entire game session and store the name which the player will select at the start of the game
/// </summary> 
[Serializable]
public static class GameInfo
{
    public static int CivilianCount;
    public static int KillsBonus;
    public static int shields;
    public static int currentPower;
    public static bool dead;
}
