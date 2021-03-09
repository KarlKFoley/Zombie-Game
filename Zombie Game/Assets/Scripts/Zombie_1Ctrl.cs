using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class controls the zombie one class
/// The basic implementation of the below code is from totorial https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// Heavly modified for project most of idology created after MainCharacterManager was complete
/// BUGs in code have been noted to be fixed for second prototype
/// </summary>
public class Zombie_1Ctrl : Zombie
{

    //Variable Declaracation for public variables

    public Transform leftEdge, rightEdge;

    void Update()
    {
        //used to check which way the zombie is moving
        if (!dead)
        {
            Move();
            FlipOnEdge();
        }
    }
    /// <summary>
    /// Used to have the zombie patrol back and forward between 2 spots
    /// will be used when collision issue is fixed with player to chase the player
    /// </summary>
    /// <param name="playerDirection"></param>
    public override void FlipOnEdge()
    {
        Vector2 playerDirection = transform.position;
        playerDirection.x = playerDirection.x - MainCharacterManager.instance.gameObject.transform.position.x;
        if (GameCtrl.instance.GetTimeLeft() > 0)
        {

            if (srFacingRight.flipX && transform.position.x <= rightEdge.position.x || playerSpotted && playerDirection.x < -.1 && srFacingRight.flipX)
            {
                srFacingRight.flipX = false;
                speedX = -speedX;
                if (playerSpotted)
                {
                    playerSpotted = false;
                }
            }
            else if (!srFacingRight.flipX && transform.position.x >= leftEdge.position.x || playerSpotted && playerDirection.x > .1 && !srFacingRight.flipX)
            {
                srFacingRight.flipX = true;
                speedX = -speedX;
                if (playerSpotted)
                {
                    playerSpotted = false;
                }

            }
        }
        else
        {

            if ( playerDirection.x < -.1 && srFacingRight.flipX)
            {

                srFacingRight.flipX = false;
                if (speedX == 0)
                {
                    speedX = -2;
                }

                speedX = -speedX;
                Move();

            }
            else if (playerDirection.x > .1 && !srFacingRight.flipX)
            {
                srFacingRight.flipX = true;
                if (speedX == 0)
                {
                    speedX = 2;
                }
                speedX = -speedX;
                Move();

            }
            else if(playerDirection.x > -.1 && playerDirection.x < .1)
            {
                speedX = 0;
            }
        }
    }
}
