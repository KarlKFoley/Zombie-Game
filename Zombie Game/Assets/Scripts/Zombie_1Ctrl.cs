using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class controls the zombie one class
/// The basic implementation of the below code is from totorial https://www.udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// Heavly modified for project most of idology created after MainCharacterManager was complete
/// BUGs in code have been noted to be fixed for second prototype
/// </summary>
public class Zombie_1Ctrl : MonoBehaviour
{

    //Variable Declaracation for public variables
    public float speedX;
    public Transform leftEdge, rightEdge;
    public Collider2D zombieSeachArea;

    //Variable Declaracation for private variables
    private const int killBonus = 10;
    private float deathDelay;
    private bool dead;
    private float attackDelay;
    private bool playerSpotted;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private Collider2D Coll;
    public new GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        //assiging vairbles for use when called on
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Coll = GetComponent<Collider2D>();
        attackDelay = 2;
        deathDelay = 2;
        dead = false;
        SetStartingDirection();
    }

    // Update is called once per frame
    void Update()
    {
        //used to check which way the zombie is moving
        Move();
        FlipOnEdge(0);
    }

    /// <summary>
    /// Used to set the zombie in a direction.
    /// </summary>
    private void Move()
    {
        Vector2 temp = rb.velocity;
        temp.x = speedX;
        rb.velocity = temp;
        if (speedX > 0 || speedX < 0)
        {
            anim.SetInteger("state", 1); // setting off animation of walking
        }
    }

    /// <summary>
    /// Used to have the zombie patrol back and forward between 2 spots
    /// will be used when collision issue is fixed with player to chase the player
    /// </summary>
    /// <param name="playerDirection"></param>
    void FlipOnEdge(float playerDirection)
    {

        
        if (sr.flipX && transform.position.x >= rightEdge.position.x)
        {
            sr.flipX = false;
            speedX = -speedX;
        }
        else if (!sr.flipX && transform.position.x <= leftEdge.position.x )
        {
            sr.flipX = true;
            speedX = -speedX;

        }
    }

    /// <summary>
    /// Assigns a starting direction
    /// Always be headed to the right
    /// </summary>
    void SetStartingDirection()
    {
        if (speedX > 0)
        {
            sr.flipX = true;
        }
        else if (speedX < 0)
        {
            sr.flipX = false;
        }
    }

    /// <summary>
    /// Used to control how collisions between all object they should come in contact with.
    /// Future implemtation if the platforms hit a zombie kill the zombie
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                if (!dead) // Stops zombie from killing player during death.
                {
                    attack();
                    PushBack(collision);
                    GameCtrl.instance.CheckShields(false, this.gameObject);
                }
                break;
            case "GROUND":
                FlipOnCollision(); // used to changed directions when zombie hits a obstical
                break;
            case "Bullet":
                GameCtrl.instance.UpdateKills(killBonus);
                ZombieDeath();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Used when a trigger collision accures.
    /// Implmentation bugged -  collision tigger isn't happening
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //BUG - having the zombie chase the player when it enters their zone - issue with Tags
        switch (collision.gameObject.tag)
        {
            case "Player":
                if (!dead)
                {
                    Vector2 temp = transform.position;
                    temp.x = temp.x - collision.gameObject.transform.position.x;
                    FlipOnEdge(temp.x);
                }
                break;
        }
    }

    /// <summary>
    /// methord flips the speed along the x axis
    /// used once the zombie hits an object
    /// </summary>
    private void FlipOnCollision()
    {
        speedX = -speedX;
        SetStartingDirection();
    }

    /// <summary>
    /// Methord conrols the animation of an attack
    /// </summary>
    private void attack()
    {
        anim.SetTrigger("attack");
        anim.SetInteger("state", 0);
        speedX = 0;
        Invoke("moveAgain", attackDelay);
    }

    /// <summary>
    /// methord starts the zombies movment after an attack
    /// need further implmenation only accounts for one direction of x - this is causing issues
    /// </summary>

    void moveAgain()
    {
        if (sr.flipX)
        {
            speedX = 2;
        }
        else
        {
            speedX = -2;
        }
    }

    /// <summary>
    /// Methord controls zombies death animation 
    /// </summary>
    public void ZombieDeath()
    {
        gameObject.layer = LayerMask.NameToLayer("Dead");
        dead = true;
        Destroy(Coll);
        anim.SetInteger("state", 2);
        speedX = 0;
        Invoke("RemoveZombie", deathDelay);
    }

    void RemoveZombie()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// When player comes into contact with the zombie the zombie is pused back by the players shield
    /// possible bug when zmobies collid because of this methord - further testing needed.
    /// </summary>
    /// <param name="objects"></param>
    void PushBack(Collision2D objects)
    {
        Vector2 dir = objects.gameObject.transform.position - transform.position;
        Debug.Log(dir);
        if (sr.flipX)
        {
            Debug.Log(gameObject.tag);
            dir.x = -5000;
        }
        else
        {
            dir.x = 5000;
        }
            rb.AddForce(dir);
    }
}
