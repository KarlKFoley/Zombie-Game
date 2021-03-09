using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class OverAllGameInfo
{
    [Header("Main")]
    public static bool LevelOneComplete;
    public static bool LevelTwoComplete;
    public static bool BossBattleComplete;
    public static int CurrentLevel;
    public static int recharge;
    public static float volume;
    public static int TotalScore;
    public static int PercentageSavedTotal;

    [Header("Level1")]
    public static int PercentageAvaibleLvl1;
    public static int PercentageSavedLvl1;

    [Header("Level2")]
    public static int PercentageAvaibleLvl2;
    public static int PercentageSavedLvl2;

    [Header("Level3")]
    public static int numberOfCiviliansSavedLvl3;
    public static int numberOfZombiesKilledLvl3;
    public static int numberOfInfectorsLvl3;
}
