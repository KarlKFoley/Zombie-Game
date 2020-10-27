using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Class handles how the main character is played
/// This class is heavly reused code from the tutorials provided during labs
/// Also reference to https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// which is the same developer from provided labs
/// Since this was the first scrip in the class and was done during the labs this code is very similar to code during those tutorials
/// Code has been modified for use in this project
/// </summary>
public class MainCharacterManager : MonoBehaviour
{

    public float speedX;
    public float jumpSpeedY;
    public GameObject leftBullet, rightBullet;
    public bool canFire, jumping, canRespawn;
    public int maxPower;
    public PowerBar powerBar;
    public GameObject garbageCtrl;

    private bool facingRight, isGrounded;
    private float speed;
    private Animator anim;
    private Rigidbody2D rb;
    private Transform firePos;
    private const int ShootingPower = 2;
    private const int RespawnPower = 5;
    private const int OrbPower = 5;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        firePos = transform.Find("firePostion");
        GameInfo.currentPower = 2;
        CheckIfCanFire();
        GameInfo.dead = false;
        maxPower = 10;
        powerBar.SetUpPower(maxPower, GameInfo.currentPower);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameInfo.tutorialComplete)
        {
            //player Movment
            movePlayer(speed);
            handleJumpAndFall();

            //Right player Movement
            if (Input.GetKeyDown(KeyCode.D))
            {
                speed = speedX;
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                if (!Input.GetKey(KeyCode.A))
                {
                    speed = 0;
                }
            }

            //Left player Movment
            if (Input.GetKeyDown(KeyCode.A))
            {
                speed = -speedX;
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                if (!Input.GetKey(KeyCode.D))
                {
                    speed = 0;
                }
            }


            //Player jump
            if (Input.GetKeyDown(KeyCode.W))
            {
                Jump();
            }


            //shooting
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fire();
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {

            }
        }
        else // need the controller
        {
            //player Movment
            movePlayer(speed);
            handleJumpAndFall();

            //Right player Movement
            if (Input.GetKeyDown(KeyCode.D))
            {
                speed = speedX;
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                if (!Input.GetKey(KeyCode.A))
                {
                    speed = 0;
                }
            }

            //Left player Movment
            if (Input.GetKeyDown(KeyCode.A))
            {
                speed = -speedX;
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                if (!Input.GetKey(KeyCode.D))
                {
                    speed = 0;
                }
            }


            //Player jump
            if (Input.GetKeyDown(KeyCode.W))
            {
                Jump();
            }


            //shooting
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fire();
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {

            }

        }
    }

    /// <summary>
    /// Handles the firing of the cannon
    /// does the animation and which way the bullet is shot from
    /// </summary>
    void fire() 
    {
        if (canFire)
        {
            AudioCtrl.instance.Shoots(gameObject.transform.position);
            anim.SetTrigger("Shoot");
            new WaitForSeconds(1f);
            if (facingRight)
            {
                Instantiate(rightBullet, firePos.position, Quaternion.identity);
            }
            if (!facingRight)
            {
                Instantiate(leftBullet, firePos.position, Quaternion.identity);
            }
            GameInfo.currentPower -= ShootingPower;
            changePowerBar(GameInfo.currentPower);
            enoughPower();
        }
    }


    /// <summary>
    /// handles the naimation of going from running to idle
    /// </summary>
    /// <param name="playerSpeed"></param>
    void movePlayer(float playerSpeed) 
    {
        Flip();
        if (playerSpeed < 0 && !jumping || playerSpeed > 0 && !jumping) 
        {
            anim.SetInteger("state", 2);
        }
        if(playerSpeed == 0 && !jumping) 
        {
            anim.SetInteger("state", 0);      
        }
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    /// <summary>
    /// handles the falling animation
    /// </summary>
    void handleJumpAndFall()
    {
        if (jumping)
        {
            if (rb.velocity.y > 0)
            {
                anim.SetInteger("state", 3);
            }else
            {
                anim.SetInteger("state", 1);
            }
        }
    }

    /// <summary>
    /// Methord helps switches the animation so the player looks like it is facing the correct way.
    /// </summary>
    void Flip()
    {
        if(speed> 0 && !facingRight || speed < 0 && facingRight) 
        {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }

    /// <summary>
    /// Colision colliders the player happens to come accross
    /// futher implmenation needed when player hits the side of an object - player currently hangs
    /// </summary>
    /// <param name="other"></param>

    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag) { 
            case "GROUND":
                hittheGround();
                break;
            case "Falling":
                hittheGround();
                break;
            case "Enemy":
                break;
        default:
            break;
        }
    }

    /// <summary>
    /// Trigger colliders the player happens to come accross
    /// futher implmenation needed for falling objects
    /// </summary>
    /// <param name="collision"></param>

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Orb":
                SFXCtrl.instance.showOrbGlow(collision.gameObject.transform.position);
                CollectOrb();
                break;
            case "Civilian":
                GameCtrl.instance.UpdateCiviliansRescued();
                break;
            case "EndLevel":
                    GameCtrl.instance.LevelComplete();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// methord for handling jump and the animation
    /// </summary>
    public void Jump() 
    { 
        if (isGrounded) 
        {
            jumping = true;
            isGrounded = false;
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
            anim.SetInteger("state", 3);
            AudioCtrl.instance.Jump(gameObject.transform.position);
        }
    }

    void hittheGround()
    {
        isGrounded = true;
        anim.SetInteger("state", 0);

    }

    /// <summary>
    /// Handles the collection or an orb
    /// </summary>

    public void CollectOrb()
    {
        GameInfo.currentPower += OrbPower;
        changePowerBar(GameInfo.currentPower);
        enoughPower();
    }

    /// <summary>
    /// changes the power level of the character
    /// missing methord to slowly charge up energy
    /// reference https://www.youtube.com/watch?v=BLfNP4Sc_iA
    /// </summary>
    /// <param name="changePower"></param>
    private void changePowerBar(int changePower)
    {
        powerBar.SetPower(GameInfo.currentPower);
    }

    /// <summary>
    /// Checks the power and changes the bool variables
    /// </summary>

    public void enoughPower()
    {
        if (GameInfo.currentPower < ShootingPower) // disables shooting if true
        {
            canFire = false;
        }
        else
        {
            canFire = true;
        }
        if (GameInfo.currentPower < RespawnPower) // disables respawning if true - not implmented currently
        {
            canRespawn = false;
        }
        else
        {
            canRespawn = true;
        }
    }
    /// <summary>
    /// Checks weather player can shoot
    /// </summary>
    void CheckIfCanFire()
    {
        if(GameInfo.currentPower >=  ShootingPower)
        {
            canFire = true;
        }
        else
        {
            canFire = false;
        }
    }


}
