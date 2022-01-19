using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnVermelho : BtnAzul
{
    public SpriteRenderer objeto_numeracao;
    private float contador;
    private bool jaFoiApertado;
    private bool contando;
    public Sprite[] sprites;

    protected override void Awake()
    {
        base.Awake();
        jaFoiApertado = false;
        contador = 0;
        contando = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Controle();
        if(apertado == 1 && !jaFoiApertado) {
            jaFoiApertado = true;
        }
    }

    protected void Controle() {
        if(contando && jaFoiApertado) {
            contador += Time.deltaTime;
            anim.SetBool("apertado", true);
            if(contador >= 0 && contador <= 1) {
                objeto_numeracao.sprite = sprites[0];
            } else if(contador > 1 && contador <= 2) {
                objeto_numeracao.sprite = sprites[1];
            } else if(contador > 2 && contador <= 3) {
                objeto_numeracao.sprite = sprites[2];
            } else if(contador > 3 && contador <= 4) {
                objeto_numeracao.sprite = sprites[3];
            } else if(contador > 4 && contador <= 5) {
                objeto_numeracao.sprite = sprites[4];
            } else {
                apertado = 0;
                contando = false;
                contador = 0;
                anim.SetBool("apertado", false);
                objeto_numeracao.sprite = null;
            }
        } else if(apertado == 1) {
            objeto_numeracao.sprite = null;
        }
    }

    protected override void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("quadrado") || 
        other.gameObject.CompareTag("quadrado2") || other.gameObject.CompareTag("quadrado3") || other.gameObject.CompareTag("quadrado4")) {
            contando = true;
            apertado = 1;
        }
    }

}
