using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieInfectorCtrl : JumpingZombie
{
    public Transform leftEdge, rightEdge;
    private float playerFoundTimer;
    public override void Start()
    {
        base.Start();
        hp = 5;
        damage = 2;
        playerFoundTimer = 3;
    }

    void Update()
    {
        //used to check which way the zombie is moving
        if (!dead)
        {
            Move();
            FlipOnEdge();
            handleJumpAndFall();
            Vector2 playerDirection = transform.position;
            playerDirection.y = MainCharacterManager.instance.gameObject.transform.position.y - playerDirection.y;
            float random = Random.Range(0.0f, 1.0f);
            if (random > .999f && !playerFound)
            {
                Jump(playerDirection);
                playerFoundTimer = 0;
            }
            if (playerFoundTimer >= 6)
            {
                playerFound = false;

            }
            else
            {
                playerFoundTimer += Time.deltaTime;
            }


        }
    }
    public override void ZombieDeath()
    {
        OverAllGameInfo.numberOfInfectorsLvl3--;
        AudioCtrl.instance.ZombieDiesSound(gameObject.transform.position);
        gameObject.layer = LayerMask.NameToLayer("Dead");
        dead = true;
        Destroy(Coll);
        anim.SetInteger("state", 2);
        speedX = 0;
        Invoke("RemoveZombie", deathDelay);

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
}
