using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Class handles the over all game play of the level
/// basic implemntation of code from tutorial https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// Modified for use in project - basic concepts from tutorial
/// for protoype 2 need to implment this to be more generic having time based of the money of civilians in game
/// time modifer needs to start zombie rush once time is out.
/// </summary>
public class GameCtrl : MonoBehaviour
{
    //Variable Declaracation for public variables
    public static GameCtrl instance;
    public float delayRespawn;
    public UI ui;
    public float startingTime;
    public int StartingShields;
    public float timeLeft;
    public int zombiesInLevel;
    public int civiliansInLevel;
    public int zombiesLeftInLevel;
    public int civiliansLeftInLevel;
    public string LevelName;
    public bool zombiesTriggered;
    public SpawnZombies zombieTrigger;
    private float zombieNoiseTimer;
    private float civilianNoiseTimer;
    private float zombieNoiseTimerWait;
    private float civilianNoiseTimerWait;
    public int levelID;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            zombiesTriggered = false;
            ResumeGame();
            timeLeft = startingTime;
            startGameVariables();
            zombieNoiseTimer = 0;
            civilianNoiseTimer = 0;
            zombieNoiseTimerWait = 0;
            civilianNoiseTimerWait = 0;
            zombiesLeftInLevel = zombiesInLevel;
            civiliansLeftInLevel = civiliansInLevel;
            delayRespawn = 2;
            OverAllGameInfo.CurrentLevel = levelID;  
        }
    }

    private void Update()
    {

        UpdateTimer();
        UpdateSoundTimer();
    }

    /// <summary>
    /// updates the how many civilians have been rescued and UI is updated
    /// </summary>
    /// <param name="Value"></param>
    public void UpdateCiviliansRescued()
    {
        civiliansLeftInLevel--;
        GameInfo.CivilianCount += 1;
        ui.Civilians_rescued.text = " x " + GameInfo.CivilianCount;
    }

    /// <summary>
    /// updates the kill counter and UI when a zombie is killed
    /// different types of zombies will have different values
    /// </summary>
    /// <param name="Value"></param>
    public void UpdateKills(int Value)
    {
        zombiesLeftInLevel--;
        GameInfo.KillsBonus += Value;
        ui.Kill_Bonus.text = "Kills Bonus:  " + (int)GameInfo.KillsBonus;
    }


    /// <summary>
    /// used when player falls off the map
    /// in current build this should not be used bcause invisible walls flank the map
    /// </summary>
    /// <param name="player"></param>

    public void PlayerFellToDeath(GameObject player)
    {
        player.SetActive(false);
        CheckShields(true, player, 0);
    }

    /// <summary>
    /// updates the timer
    /// curently only counts down nothing happens after 0 time is left
    /// need implmenation for zombie horde
    /// from tutorial
    /// </summary>
    void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft > 0)
        {
            ui.Timer.text = "Timer: " + (int)timeLeft;
        }

        if(timeLeft <= 0)
        {
            ui.Timer.text = "Timer: 0";
            if (!zombiesTriggered)
            {
                zombiesTriggered = true;
                StartCoroutine(zombieTrigger.ZombieWave());
            }
        }
    }

    void UpdateSoundTimer()
    {
        zombieNoiseTimer += Time.deltaTime;
        civilianNoiseTimer += Time.deltaTime;
        zombieNoiseTimerWait -= Time.deltaTime;
        civilianNoiseTimerWait -= Time.deltaTime;
        if (Mathf.Floor(zombieNoiseTimer) % 3 == 0 && zombieNoiseTimerWait <= 0)
        {
            zombieNoiseTimerWait = 3f;
            GameObject[] zombies;
            zombies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach( GameObject zombie in zombies)
            {
                AudioCtrl.instance.ZombieSound(zombie.transform.position);
            }

        }
        if (Mathf.Floor(civilianNoiseTimer) % 5 == 0 && civilianNoiseTimerWait <= 0)
        {
            civilianNoiseTimerWait = 5f;
            GameObject[] Civilians;
            Civilians = GameObject.FindGameObjectsWithTag("Civilian");
            foreach (GameObject Civilian in Civilians)
            {
                AudioCtrl.instance.CivilianHelp(Civilian.transform.position);
            }

        }
    }

    /// <summary>
    /// reset the levels scores for each attempt
    /// </summary>

    void startGameVariables()
    {
        GameInfo.shields = StartingShields;
        GameInfo.KillsBonus = 0;
        GameInfo.CivilianCount = 0;
    }

    /// <summary>
    /// Updates the shield icons in the top right of the hud
    /// </summary>
    void UpdateShields()
    {
        switch (GameInfo.shields)
        {
            case 3:
                ui.shield3.color = new Color32(0, 0, 0, 150);
                break;
            case 2:
                ui.shield3.color = new Color32(0, 0, 0, 150);
                ui.shield2.color = new Color32(0, 0, 0, 150);
                break;
            case 1:
                ui.shield3.color = new Color32(0, 0, 0, 150);
                ui.shield2.color = new Color32(0, 0, 0, 150);
                ui.shield1.color = new Color32(0, 0, 0, 150);
                break;
            case 0:
                ui.shield3.color = new Color32(255, 0, 0, 150);
                ui.shield2.color = new Color32(255, 0, 0, 150);
                ui.shield1.color = new Color32(255, 0, 0, 150);
                ui.shield0.color = new Color32(255, 0, 0, 150);
                break;
            case -1:
                break;
            default: 
                break;
        }
        AudioCtrl.instance.ShieldDamage(MainCharacterManager.instance.transform.position);
    }

    /// <summary>
    /// Methord handles taking damage from the zombie
    /// checking if they have died or not.
    /// </summary>
    /// <param name="Death"></param>
    /// <param name="player"></param>
     public void CheckShields(bool Death, GameObject player, int damage)
    {
        GameInfo.shields -= damage;
        UpdateShields();

        if (GameInfo.shields == -1)
        {
            player.gameObject.layer = LayerMask.NameToLayer("Dead");
            playerDied(player);
            Invoke("Respawn", delayRespawn);
        }
        else if(Death)
        {
            player.gameObject.layer = LayerMask.NameToLayer("Dead");
            playerDied(player);
            Invoke("Respawn", delayRespawn);
        }
    }

    
    /// <summary>
    /// Methord handles the dieing animation of the player 
    /// this might need to be moved to the player manager
    /// </summary>
    /// <param name="player"></param>
    void playerDied(GameObject player)
    {
        MainCharacterManager.instance.Death();
        GameInfo.dead = true;
    }

    /// <summary>
    /// brings up end game screen
    /// need more information on the reason for the game over - futher implmenation
    /// </summary>
    void GameOver()
    {
        ui.GameOver.SetActive(true);
        PauseGame();
    }

    /// <summary>
    /// used when player dies or falls to either death
    /// </summary>
    void Respawn()
    {
        SceneManager.LoadScene(LevelName);
    }


    /// <summary>
    /// /// used to pause game when needed
    /// got code from https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0;
    }


    /// <summary>
    /// used to resume game after the game is paused
    /// got code from https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/
    /// </summary>
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    /// <summary>
    /// Methord switches to the complete level scene
    /// if they didnt save all 3 civilians they have failed
    /// </summary>

    public void LevelComplete()
    {
        GameInfo.PercentageSaved = (10 - zombiesLeftInLevel - civiliansLeftInLevel) * 10;
        OverAllGameInfo.TotalScore += GameInfo.KillsBonus;
        string sceneName = "";
        if (OverAllGameInfo.CurrentLevel!=2)
        {
            sceneName = "Level_Complete";
        }
        else
        {
            sceneName = "Game_Complete";
        }

        SceneManager.LoadScene(sceneName);

    }

    /// <summary>
    /// used orginally for when dealing with an instance it returns the bonus kills
    /// more then likely will be removed from becuase information is now in a static class
    /// </summary>
    /// <returns>Int for the score</returns>
    public int GetScore()
    {
        return GameInfo.KillsBonus;
    }

    /// <summary>
    /// used orginally for when dealing with an instance it returns the civilians saved int
    /// more then likely will be removed from becuase information is now in a static class
    /// </summary>
    /// <returns>Int for the civilians saved</returns>
    public int GetCivilianCount()
    {
        return GameInfo.CivilianCount;
    }

    public int GetPercentageSaved()
    {
        return GameInfo.PercentageSaved;
    }

    public float GetTimeLeft()
    {
        return timeLeft;
    } 
}
