using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circulo : MonoBehaviour
{
    public Transform lugar_que_vai;
    public GameObject[] quadrado;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("quadrado")) {
            Instantiate(quadrado[0], lugar_que_vai.position, lugar_que_vai.rotation);
        } else if(other.gameObject.CompareTag("quadrado2")) {
            Instantiate(quadrado[1], lugar_que_vai.position, lugar_que_vai.rotation);
        } else if(other.gameObject.CompareTag("quadrado3")) {
            Instantiate(quadrado[2], lugar_que_vai.position, lugar_que_vai.rotation);
        } else if(other.gameObject.CompareTag("quadrado4")) {
            Instantiate(quadrado[3], lugar_que_vai.position, lugar_que_vai.rotation);
        }  
    }
}
