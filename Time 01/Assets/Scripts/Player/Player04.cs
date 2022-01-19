using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player04 : Player03
{
    protected bool pulando;
    public Transform spawn_tiro;
    public GameObject tiro_player;
    protected float cont = 0;

    protected override void move(){
        float horizontalForceButton = Input.GetAxis ("Horizontal");
        rb2d.velocity = new Vector2 (horizontalForceButton * speed, rb2d.velocity.y);
        isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.1f, whatIsGround);
        
        if ((horizontalForceButton > 0  && !lookingRight) || (horizontalForceButton < 0 && lookingRight)) {
            Flip ();
        }

        if(horizontalForceButton != 0 && isGrounded && !jump) {
            anim.SetBool("andando", true);
        } else {
            anim.SetBool("andando", false);
        }

        if (jump) {
            rb2d.AddForce(new Vector2(0, jumpForce));
            anim.SetBool("pulou", true);
            pulando = true;
            jump = false;
        }

        if((Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(0))) {
               Fire();
            } else if((Input.GetKey(KeyCode.X) || Input.GetMouseButton(0))) {
               cont += Time.deltaTime;
               if(cont >= 0.35f) {
                  Fire();
                  cont = 0;
               }
            }

    }

    protected override void identificarChao() {
      if(isGrounded && pulando) {
            pulando = false;
            doubleJump = true;
            anim.SetBool("pulou", false);
        } else if(isGrounded) {
            doubleJump = true;
        }
   }
    
    void Fire() {
		GameObject cloneBullet = Instantiate(tiro_player, spawn_tiro.position, spawn_tiro.rotation);

        if(!lookingRight)
			cloneBullet.transform.eulerAngles = new Vector3(0, 0, 180);
	}
}
