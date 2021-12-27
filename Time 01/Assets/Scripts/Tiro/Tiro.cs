using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    protected Rigidbody2D corpo_tiro;
    protected float velocidade;
    protected float tempo_para_morrer;
    protected bool olhando_esquerda;

    void Start()
    {
        velocidade = 0.8f;
        tempo_para_morrer = 3f;
        corpo_tiro = GetComponent<Rigidbody2D>();
        if(transform.rotation.z >= 0) {
            olhando_esquerda = true;
        } else {
            olhando_esquerda = false;
        }
        Destroy(gameObject, tempo_para_morrer);
    }

    // Update is called once per frame
    void Update()
    {
        IrNe(olhando_esquerda);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == gameObject.tag || 
        other.gameObject.CompareTag("quadrado") || other.gameObject.CompareTag("quadrado2")  || other.gameObject.CompareTag("quadrado3")) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }

    protected void IrNe(bool i) {
        if(i) {
            corpo_tiro.velocity = new Vector2(-velocidade, 0);
        } else {
            corpo_tiro.velocity = new Vector2(velocidade, 0);
        }
    }
}
