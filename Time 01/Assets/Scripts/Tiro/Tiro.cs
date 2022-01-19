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

    protected virtual void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("quadrado") || other.gameObject.CompareTag("quadrado2")  || other.gameObject.CompareTag("quadrado3")) {
            Destroy(gameObject);
        } else if(other.gameObject.tag == gameObject.tag) {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
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
