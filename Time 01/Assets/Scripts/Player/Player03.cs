using UnityEngine;
using System.Collections;
public class Player03 : Player {

    protected override void Update() {
        base.Update();
        if(spawn_um) {
            anim.SetBool("carregar", true);
        } else {
            anim.SetBool("carregar", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.CompareTag("quadrado") || other.gameObject.CompareTag("quadrado2") || other.gameObject.CompareTag("quadrado3") || 
      other.gameObject.CompareTag("quadrado4")) {
          spawn_um = true;
      }
   }
}
