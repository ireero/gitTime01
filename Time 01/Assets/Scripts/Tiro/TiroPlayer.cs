using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPlayer : Tiro
{
    protected override void Direcao() {
        if(Player04.lookingRight) {
            corpo_tiro.velocity = new Vector2(velocidade, 0);
        } else {
            corpo_tiro.velocity = new Vector2(-velocidade, 0);
        }
    }

}
