using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn : MonoBehaviour
{
    protected BoxCollider2D collider_btn;
    protected Animator anim;
    protected int apertado;
    public static int liberado;

    protected virtual void Awake()
    {
        liberado = 0;
        apertado = 0;
        collider_btn = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
            if(apertado == 0) {
            if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("quadrado") || 
            other.gameObject.CompareTag("quadrado2") || other.gameObject.CompareTag("quadrado3") || other.gameObject.CompareTag("quadrado4")) {
                anim.SetBool("apertado", true);
                liberado++;
                }
                apertado++;
            }
            
    }

    protected virtual void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("quadrado") || 
        other.gameObject.CompareTag("quadrado2") || other.gameObject.CompareTag("quadrado3") || other.gameObject.CompareTag("quadrado4")) {
            if(apertado == 1) {
                liberado--;
                anim.SetBool("apertado", false);
                apertado = 0;
            } else {
                apertado--;
            }
        }
    }
}
