using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class JumpingZombie : Zombie
    {
    public bool isGrounded;
    public override void Start()
        {
            base.Start();
            isGrounded = true;
        }
        protected void Jump(Vector2 playersDirection)
        {
        if (isGrounded)
            {

                jumping = true;
                isGrounded = false;
                rb.AddForce(new Vector2(rb.velocity.x, 500));
                anim.SetInteger("state", 3);
        }
        }
        protected void handleJumpAndFall()
        {
            if (jumping)
            {
                if (rb.velocity.y > 0)
                {
                    anim.SetInteger("state", 3);
                }
                else
                {
                    anim.SetInteger("state", 1);
                }
            }
        }
        public void hittheGround()
        {
        isGrounded = true;
        anim.SetInteger("state", 0);

        }

    }
