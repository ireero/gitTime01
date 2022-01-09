using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    protected Rigidbody2D corpo_tiro;
    protected float velocidade = 0.8f;
    protected float tempo_para_morrer = 3f;
    protected bool olhando_esquerda;

    void Start()
    {
        corpo_tiro = GetComponent<Rigidbody2D>();
        Direcao();
        Destroy(gameObject, tempo_para_morrer);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == gameObject.tag || 
        other.gameObject.CompareTag("quadrado") || other.gameObject.CompareTag("quadrado2")  || other.gameObject.CompareTag("quadrado3") || 
        other.gameObject.CompareTag("bullet_player")) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }

    protected virtual void Direcao() {
        if(transform.rotation.z >= 0) {
            corpo_tiro.velocity = new Vector2(-velocidade, 0);
        } else {
            corpo_tiro.velocity = new Vector2(velocidade, 0);
        }
    }
}
