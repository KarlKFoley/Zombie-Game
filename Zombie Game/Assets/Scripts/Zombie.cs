using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{    
    //Variable Declaracation for public variables
    public float speedX;


    //Variable Declaracation for private variables
    public int killBonus;
    protected float deathDelay= 2;
    public bool dead;
    protected float attackDelay = 2;
    public bool playerSpotted;
    protected Rigidbody2D rb;
    protected SpriteRenderer srFacingRight;
    protected Animator anim;
    protected Collider2D Coll;
    public new GameObject gameObject;
    protected int hp;
    public bool jumping;
    protected int damage;
    public bool playerFound;
    // Start is called before the first frame update
    public virtual void Start()
    {
        //assiging vairbles for use when called on
        rb = GetComponent<Rigidbody2D>();
        srFacingRight = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Coll = GetComponent<Collider2D>();
        hp = 2;
        dead = false;
        playerSpotted = false;
        jumping = false;
        SetStartingDirection();
        damage = 1;
    }

        /// <summary>
        /// Used to control how collisions between all object they should come in contact with.
        /// Future implemtation if the platforms hit a zombie kill the zombie
        /// </summary>
        /// <param name="collision"></param>
        protected void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                if (!dead) // Stops zombie from killing player during death.
                {
                    attack();
                    PushBack();
                    GameCtrl.instance.CheckShields(false, this.gameObject, damage);
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

    public virtual void FlipOnEdge()
    { }
        /// <summary>
        /// Assigns a starting direction
        /// Always be headed to the right
        /// </summary>
        protected void SetStartingDirection()
    {
        if (speedX > 0)
        {
            srFacingRight.flipX = false;
        }
        else if (speedX < 0)
        {
            srFacingRight.flipX = true;
        }
    }
    /// <summary>
    /// Used to set the zombie in a direction.
    /// </summary>
    protected void Move()
    {
        Vector2 temp = rb.velocity;
        temp.x = speedX;
        rb.velocity = temp;
        if (speedX > 0 || speedX < 0)
        {
            anim.SetInteger("state", 1); // setting off animation of walking
        }
        else
        {
            anim.SetInteger("state", 0);
        }
    }
    public void TakeDamage()
    {
        hp--;
        if (hp <= 0)
        {
            ZombieDeath();
            GameCtrl.instance.UpdateKills(killBonus);
        }
        else
        {
            PushBack();
        }
    }
    /// <summary>
    /// When player comes into contact with the zombie the zombie is pused back by the players shield
    /// </summary>
    /// <param name="objects"></param>
    protected void PushBack()
    {
        Vector2 dir = MainCharacterManager.instance.gameObject.transform.position - transform.position;
        if (dir.x > 0f)
        {

            dir.x = -5000;
        }
        else
        {
            dir.x = 5000;
        }
        rb.AddForce(dir);
    }
    /// <summary>
    /// Methord controls zombies death animation 
    /// </summary>
    public virtual void ZombieDeath()
    {
        AudioCtrl.instance.ZombieDiesSound(gameObject.transform.position);
        gameObject.layer = LayerMask.NameToLayer("Dead");
        dead = true;
        Destroy(Coll);
        anim.SetInteger("state", 2);
        speedX = 0;
        Invoke("RemoveZombie", deathDelay);
    }

    protected void RemoveZombie()
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// Methord conrols the animation of an attack
    /// </summary>
    protected void attack()
    {
        anim.SetTrigger("attack");
        speedX = 0;
        Invoke("moveAgain", attackDelay);
    }

    /// <summary>
    /// methord starts the zombies movment after an attack
    /// need further implmenation only accounts for one direction of x - this is causing issues
    /// </summary>

    protected void moveAgain()
    {
        if (srFacingRight.flipX)
        {
            speedX = -2;
        }
        else
        {
            speedX = 2;
        }
    }
    /// <summary>
    /// methord flips the speed along the x axis
    /// used once the zombie hits an object
    /// </summary>
    protected void FlipOnCollision()
    {
        speedX = -speedX;
        SetStartingDirection();
    }
}
