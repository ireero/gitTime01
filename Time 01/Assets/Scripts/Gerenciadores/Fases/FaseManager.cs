using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseManager : MonoBehaviour
{
    public GameObject painel_reiniciar;
    private int valorFase;
    private int valorLiberado;

    public static FaseManager Instance {get; private set;}

    void Start()
    {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        valorFase = SceneManager.GetActiveScene().buildIndex;
        
         RecuperarValores();

        if(Btn.liberado >= valorLiberado) {
            SceneManager.LoadSceneAsync(valorFase + 1);
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            painel_reiniciar.SetActive(true);
        }

        }


    public void Reiniciar() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    void RecuperarValores() {
        if(valorFase == 1 || valorFase == 2 || valorFase == 3 || valorFase == 5 || valorFase == 6 || valorFase == 7 || valorFase == 8
        || valorFase == 15 || valorFase == 16 || valorFase == 17 || valorFase == 21 || valorFase == 24 || valorFase == 28
        || valorFase == 30 || valorFase == 31) {
                valorLiberado = 1;
            } else if(valorFase == 4 || valorFase == 10 || valorFase == 12 || valorFase == 13 || valorFase == 14 || valorFase == 18
            || valorFase == 20 || valorFase == 22 || valorFase == 25 || valorFase == 26 || valorFase == 27 || valorFase == 32) {
                valorLiberado = 2;
            } else if(valorFase == 9 || valorFase == 11 || valorFase == 19) {
                valorLiberado = 3;
            } else if(valorFase == 23 || valorFase == 29) {
                valorLiberado = 4;
            }  
    }

 }
