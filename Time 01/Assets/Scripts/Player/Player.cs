using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class Player : MonoBehaviour {
   public Transform groundCheck;
   public Transform spawn_troca;
   protected float speed = 1.5f;
   protected float jumpForce = 80f;
   public LayerMask whatIsGround;
 
   [HideInInspector]
   public static bool lookingRight = true;

   public static bool player_morto;
 
   protected Rigidbody2D rb2d;
   protected bool isGrounded = false;
   protected bool jump = false;

   protected Animator anim;

   public static bool pode_mexer;

   protected CapsuleCollider2D player_collider;

   protected SpriteRenderer sr;

   protected bool doubleJump;

   protected Vector2 vetor_posicao;
   protected bool spawn_um;

   protected int n_quadrado;

   public GameObject[] quadrados;
   
   protected bool pode_trocar;
   protected GameObject objeto;

   protected bool algo_em_cima;

   public PhysicsMaterial2D segurar;

   protected bool abaixado;
 
   void Start () {  
      abaixado = false;
      spawn_um = false;
      pode_trocar = false;
      pode_mexer = true;
      doubleJump = true;
      player_morto = false;
      player_collider = GetComponent<CapsuleCollider2D>();
      Physics2D.IgnoreLayerCollision(3, 9, false);
      anim = GetComponent<Animator>();
      rb2d = GetComponent<Rigidbody2D>();
      sr = GetComponent<SpriteRenderer>();
      Physics2D.IgnoreLayerCollision(7,8);
   }
 
   protected virtual void Update () {
      
      if(pode_mexer) {
         inputCheck ();
         move ();
      }

      identificarChao();
   }
 
   void inputCheck () {
      puloMecanica();
      ficarAbaixado();
      }
 
   protected virtual void move(){
      float horizontalForceButton = Input.GetAxis ("Horizontal");
      rb2d.velocity = new Vector2 (horizontalForceButton * speed, rb2d.velocity.y);
      isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.1f, whatIsGround);
 
      if ((horizontalForceButton > 0  && !lookingRight) || (horizontalForceButton < 0 && lookingRight)) {
         Flip ();
      }

      if (jump) {
         rb2d.AddForce(new Vector2(0, jumpForce));
         jump = false;
      }
   }

   protected virtual void ficarAbaixado() {
      if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
         if(pode_trocar) {
            Trocar(objeto);
         }
         anim.SetBool("abaixar", true);
         speed = 0.8f;
      } else {
          anim.SetBool("abaixar", false);
         speed = 1.5f;
      }
   }

   protected virtual void puloMecanica() {
      if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded) {
      jump = true;
      } else if(((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded)) {
         jump = true;
      } else if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && !isGrounded && doubleJump) {
            jump = true;
            doubleJump = false;
      }
   }

   protected virtual void identificarChao() {
      if(isGrounded) {
         doubleJump = true;
      }
   }
 
   public void Flip(){
      lookingRight = !lookingRight;
      Vector3 myScale = transform.localScale;
      myScale.x *= -1;
      transform.localScale = myScale;
   }

   private void OnCollisionEnter2D(Collision2D other) {
      if(other.gameObject.CompareTag("quadrado")) {
         QualQuadrado(1, other);
      } else if(other.gameObject.CompareTag("quadrado2")) {
         QualQuadrado(2, other);
      } else if(other.gameObject.CompareTag("quadrado3")) {
         QualQuadrado(3, other);
      } else if(other.gameObject.CompareTag("quadrado4")) {
         QualQuadrado(4, other);
      } else if(other.gameObject.CompareTag("armadilha")) {
         Destroy(gameObject);
      } else if(other.gameObject.CompareTag("plataforma_move")) {
         player_collider.sharedMaterial = segurar;
      } else if(other.gameObject.CompareTag("bullet_player")) {
         Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      }
   }

   private void OnCollisionExit2D(Collision2D other) {
      if(other.gameObject.CompareTag("quadrado") || other.gameObject.CompareTag("quadrado2") || other.gameObject.CompareTag("quadrado3")
      || other.gameObject.CompareTag("quadrado4")) {
         spawn_um = false;
         pode_trocar = false;
      } else if(other.gameObject.CompareTag("plataforma_move")) {
         player_collider.sharedMaterial = null;
      }
   }

   private void OnCollisionStay2D(Collision2D other) {
      if(other.gameObject.CompareTag("quadrado") || other.gameObject.CompareTag("quadrado2") || other.gameObject.CompareTag("quadrado3")) {
         vetor_posicao = other.gameObject.transform.position;
      }
   }

   private void Trocar(GameObject other) {
      if(!spawn_um) {
         Destroy(other);
         switch(n_quadrado) {
            case 1:
               Instantiate(quadrados[0], spawn_troca.position, spawn_troca.rotation);
               break;
            case 2:
               Instantiate(quadrados[1], spawn_troca.position, spawn_troca.rotation);
               break;
            case 3:
               Instantiate(quadrados[2], spawn_troca.position, spawn_troca.rotation);
               break; 
            case 4:
               Instantiate(quadrados[3], spawn_troca.position, spawn_troca.rotation); 
               break;          
         }
         transform.position = vetor_posicao;
         spawn_um = true;
      }
   }

   private void QualQuadrado(int n, Collision2D colisor) {
      this.n_quadrado = n;
      pode_trocar = true;
      vetor_posicao = colisor.gameObject.transform.position;
      objeto = colisor.gameObject;
   }
   
}