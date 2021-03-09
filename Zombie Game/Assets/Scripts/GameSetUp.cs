using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {

        OverAllGameInfo.LevelOneComplete = false;
        OverAllGameInfo.LevelTwoComplete = false;
        OverAllGameInfo.BossBattleComplete = false;
        OverAllGameInfo.CurrentLevel = 0;
        OverAllGameInfo.recharge = 10;
        OverAllGameInfo.PercentageSavedTotal = 0;
        ///Level 1
        OverAllGameInfo.PercentageAvaibleLvl1 = 10;
        OverAllGameInfo.PercentageSavedLvl1 = 0;

        ///Level 2
        OverAllGameInfo.PercentageAvaibleLvl1 = 20;
        OverAllGameInfo.PercentageSavedLvl2 = 0;

        ///Level Boss
        OverAllGameInfo.numberOfCiviliansSavedLvl3 =0;
        OverAllGameInfo.numberOfCiviliansSavedLvl3 = 0;
        OverAllGameInfo.numberOfInfectorsLvl3 = 4;
    }

}
