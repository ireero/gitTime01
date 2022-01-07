using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player04 : Player
{


    // Update is called once per frame
    protected virtual void Update()
    {
        base.Update();
    }

    protected override void move(){
        base.move();
        float horizontalForceButton = Input.GetAxis ("Horizontal");
        rb2d.velocity = new Vector2 (horizontalForceButton * speed, rb2d.velocity.y);
        isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.1f, whatIsGround);
        
        if ((horizontalForceButton > 0  && !lookingRight) || (horizontalForceButton < 0 && lookingRight)) {
            Flip ();
        }

        if(horizontalForceButton != 0 && isGrounded) {
            anim.SetBool("andando", true);
        } else {
            anim.SetBool("andando", false);
        }

        if (jump) {
            rb2d.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }

    }
}
