using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Quadrados : MonoBehaviour
{

    protected Rigidbody2D corpo;
    protected float forca_lancamento = 8f;
    protected bool ser_lancado;
    protected bool lancou;
    protected BoxCollider2D collider_quad;
    protected int fase_atual;


    protected virtual void Awake() {
        lancou = false;
        ser_lancado = false;
        corpo = GetComponent<Rigidbody2D>();
        collider_quad = GetComponent<BoxCollider2D>();
        fase_atual = SceneManager.GetActiveScene().buildIndex;
    }

    protected virtual void Update() {
        if(ser_lancado) {
            if(Input.GetKeyDown(KeyCode.Z)) {
                Lancar();
            }
        }
    }

    protected void Lancar() {
        if(Player.lookingRight) {
            corpo.AddForce(new Vector2(forca_lancamento, forca_lancamento));
        } else {
            corpo.AddForce(new Vector2( -1 * forca_lancamento, forca_lancamento));
        }
        lancou = true;
        ser_lancado = false;
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("buraco_negro")) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            ser_lancado = true;        
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            ser_lancado = false;
        }
    }


}