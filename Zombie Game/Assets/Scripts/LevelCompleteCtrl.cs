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
    public Text Storyinfo;

    // Start is called before the first frame update
    //This only is run when the player returns with three civilians
    void Start()
    {
        int score = GameCtrl.instance.GetScore();
        int saved = GameCtrl.instance.GetCivilianCount();
        txtScore.text = " " + score;
        txtRescued.text = " " + saved;
        float PercentageSaved = (float)GameInfo.PercentageSaved/100f;
        float percentageAvaible =0;
        switch (OverAllGameInfo.CurrentLevel)
        {
            case 0:
               ;
                OverAllGameInfo.PercentageSavedLvl1 = (int)(PercentageSaved*100f);
                percentageAvaible = OverAllGameInfo.PercentageAvaibleLvl1;
                break;
            case 1:
                OverAllGameInfo.PercentageSavedLvl1 = (int)(PercentageSaved * 100f);
                percentageAvaible = OverAllGameInfo.PercentageAvaibleLvl1;
                break;
            default:
                break;

        }
        OverAllGameInfo.recharge += (int)(percentageAvaible * PercentageSaved);
        OverAllGameInfo.PercentageSavedTotal += (int)Mathf.Floor((percentageAvaible * PercentageSaved));
        Storyinfo.text = "You Managed to Saved "+ saved + " Civilians and killed " + ( GameCtrl.instance.zombiesInLevel -GameCtrl.instance.zombiesLeftInLevel)+ " zombies that where in the zone before the zombie horde arrived\n You have saved "
                + (percentageAvaible * PercentageSaved) + "% of the future population \n You power will now recharge at " + OverAllGameInfo.recharge + "%";
        OverAllGameInfo.CurrentLevel++;
    }
}
