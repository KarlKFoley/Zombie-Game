using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
/// This Script stores variables that are unsed in the instance of Gamectrl
/// below code came from online tutorial https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// Modifcation of variable and methods to suit project
/// </summary> 
public class AudioCtrl : MonoBehaviour
{

    public static AudioCtrl instance;
    public PlayerAudio playerAudio;
    public Transform player;

    public bool soundOn;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    /// <summary>
    /// Plays jumping sound at the players location
    /// </summary>
    /// <param name="position"></param>
     public void Jump(Vector3 position)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(playerAudio.playerjumps,position, 52f);
        }
    }
    /// <summary>
    /// Plays shooting sound at the players location
    /// </summary>
    /// <param name="position"></param>
    public void Shoots(Vector3 position)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(playerAudio.playerShoots, position);
        }
    }
    /// <summary>
    /// Plays zombie sound at the zombies location location
    /// not implemented caused issues with over use of audio
    /// </summary>
    /// <param name="position"></param>
    public void ZombieSound(Vector3 position)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(playerAudio.zombieSound, position);
        }
    }

    public void ZombieDiesSound(Vector3 position)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(playerAudio.ZombieDeathSound, position);
        }
    }


    public void CivilianHelp(Vector3 position)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(playerAudio.CivilianHelpSound, position);
        }
    }

    public void CivilianSave(Vector3 position)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(playerAudio.CivilianSaveSound, position);
        }
    }

    public void ShieldDamage(Vector3 position)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(playerAudio.ShieldDamageSound, position);
        }
    }

    public void robotDies(Vector3 position)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(playerAudio.PlayerDies, position);
        }
    }

    public void playerMoves(Vector3 position)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(playerAudio.playerWalks, position, .4f);
        }
    }

}
