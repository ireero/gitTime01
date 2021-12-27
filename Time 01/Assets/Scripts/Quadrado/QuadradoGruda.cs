using UnityEngine;
using System.Collections;

public class QuadradoGruda : Quadrados
{

    protected override void Awake() {
        base.Awake();
    }

    protected override void Update() {
        base.Update();
    }

    private void OnCollisionEnter2D(Collision2D other) {
         if(other.gameObject.CompareTag("plataforma") || other.gameObject.CompareTag("parede") || other.gameObject.CompareTag("btn")) {
            corpo.bodyType = RigidbodyType2D.Static;
        } else if(other.gameObject.CompareTag("buraco_negro")) {
            Destroy(gameObject);
        } else if(other.gameObject.CompareTag("armadilha")) {
            corpo.bodyType = RigidbodyType2D.Static;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("armadilha")) {
            corpo.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
