using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadradoRoxo : Quadrados
{
    public GameObject luz;
    public PhysicsMaterial2D segurar;
    private float tempo_parar;

    protected override void Awake()
    {
        base.Awake();
        tempo_parar = 0.5f;
        lancou = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if(lancou) {
            if(Input.GetKeyDown(KeyCode.X)) {
                corpo.bodyType = RigidbodyType2D.Static;
                luz.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("plataforma_move")) {
            collider_quad.sharedMaterial = segurar;
            lancou = false;
        } else if(other.gameObject.CompareTag("buraco_negro")) {
            Destroy(gameObject);
        } else if(other.gameObject.CompareTag("chao") || other.gameObject.CompareTag("Player") 
        || other.gameObject.CompareTag("plataforma") || other.gameObject.CompareTag("btn")) {
            lancou = false;
        } else if(other.gameObject.CompareTag("armadilha")) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("chao") || other.gameObject.CompareTag("Player") 
        || other.gameObject.CompareTag("plataforma") || other.gameObject.CompareTag("btn")) {
            lancou = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("plataforma_move")) {
            collider_quad.sharedMaterial = null;
        } else if(other.gameObject.CompareTag("chao") || other.gameObject.CompareTag("Player") 
        || other.gameObject.CompareTag("plataforma") || other.gameObject.CompareTag("btn")) {
            lancou = true;
        }
    }
}
