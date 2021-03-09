using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class controls the zombie one class
/// The basic implementation of the below code is from totorial https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// Heavly modified for project most of idology created after MainCharacterManager was complete
/// BUGs in code have been noted to be fixed for second prototype
/// </summary>
public class Zombie_2Ctrl : JumpingZombie
{

    void Update()
    {
        //used to check which way the zombie is moving
        if (!dead)
        {
            Move();
            FlipOnEdge();
            handleJumpAndFall();
            Vector2 playerDirection = transform.position;
            playerDirection.y = MainCharacterManager.instance.gameObject.transform.position.y - playerDirection.y ;
            if (playerDirection.y>.5f)
            {
                Jump(playerDirection);
            }

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
        if (playerDirection.x < -.1 && srFacingRight.flipX)
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
        else if (playerDirection.x > -.1 && playerDirection.x < .1)
        {
            speedX = 0;
        }
    }



}
