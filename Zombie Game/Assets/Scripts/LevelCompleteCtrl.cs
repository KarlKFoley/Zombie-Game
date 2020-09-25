using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>
/// This Script controls the complete level
/// Idea of formating came from online tutorial https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// Modification to suit the needs of the project and changed to work with a static class
/// </summary> 
public class LevelCompleteCtrl : MonoBehaviour
{
    public Text txtScore;
    public Text txtRescued;

    // Start is called before the first frame update
    //This only is run when the player returns with three civilians
    void Start()
    {
        int score = GameCtrl.instance.GetScore();
        int saved = GameCtrl.instance.GetCivilianCount();
        txtScore.text = " " + score;
        txtRescued.text = " " + saved;
    }
}
