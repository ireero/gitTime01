using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color cor_atual;
    private PlatformEffector2D efeito;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cor_atual = sr.color;    
        efeito = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("quadrado")) {
            if(sr.color == new Color(0, 0, 0)) {
                sr.color = Color.black;
                efeito.colliderMask = 5;
            } else {
                sr.color = Color.grey;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("quadrado")) {
            sr.color = cor_atual;
        }
    }
}
