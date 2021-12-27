using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Time06 : MonoBehaviour
{
    public GameObject painel_reiniciar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Btn.liberado >= 1) {
            SceneManager.LoadSceneAsync("Time07");
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            painel_reiniciar.SetActive(true);
        }
    }

    public void Reiniciar() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
