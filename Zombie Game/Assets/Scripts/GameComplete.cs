using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameComplete : MonoBehaviour
{
    public Text txtScore;
    public Text txtRescued;
    public Text Storyinfo;

    // Start is called before the first frame update
    //This only is run when the player returns with three civilians
    void Start()
    {
        float PercentageSaved = (float)GameInfo.PercentageSaved / 100f;
        OverAllGameInfo.PercentageSavedTotal += (int)Mathf.Floor((10 * PercentageSaved));
        int score = OverAllGameInfo.TotalScore;
        int saved = OverAllGameInfo.PercentageSavedTotal;
        txtScore.text = " " + score;
        txtRescued.text = " " + saved +" %";

        Storyinfo.text = "As you reported the sucess of your mission back to the commander. Before he could get a word out you blink out of existence \n"
            +"You were never created because the infection never left this city";
        OverAllGameInfo.CurrentLevel++;
    }
}
