using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirador : MonoBehaviour
{

    public Transform spawn_tiro;
    public GameObject tiro;
    protected float taxa_de_tiro;
    protected float contador;

    void Start()
    {
        contador = 0;
        if(tiro.tag == "chao") {
            taxa_de_tiro = 4f;
        } else {
            taxa_de_tiro = 2.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;
        if(contador >= taxa_de_tiro) {
            Instantiate(tiro, spawn_tiro.position, spawn_tiro.rotation);
            contador = 0;
        }
    }
}
