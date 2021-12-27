using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadradoDeVidro : Quadrados
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("chao") || other.gameObject.CompareTag("Player")) {
            StartCoroutine("esperarParaCair");    
        }
    }

    public void Destruir() {
        Destroy(this.gameObject);
    }

    IEnumerator esperarParaCair() {
        yield return new WaitForSeconds(0.37f);
        anim.SetBool("despedacar", true);
        corpo.bodyType = RigidbodyType2D.Dynamic;
    }
}
