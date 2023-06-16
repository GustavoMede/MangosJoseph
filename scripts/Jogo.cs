using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Jogo : MonoBehaviour
{
    public float modificadorDeVelocidade = 0.01f;

    public float velocidade = 6f;

    public float velocidadeMaxima = 12f;

    private void Update() {
        velocidade = Mathf.Clamp(
            velocidade + modificadorDeVelocidade * Time.deltaTime,
            0,
            velocidadeMaxima
        );
    }

    public void ReiniciarJogo() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
 