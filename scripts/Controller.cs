using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float forcaPulo;
    public LayerMask layerChao;
    private bool estaNoChao;
    public float distanciaMinimaChao;
    private float pontos;
    private float highscore;
    private float multiplicadorPontos = 9f;
    public Text pontosText;
    public Text highscoreText;
    public Animator animatorComponent;
    public float limiarDeQueda = -3f;

    private void Start() {
        apresentaHighscore();
    }

    private void apresentaHighscore() {
        highscore = PlayerPrefs.GetFloat("HIGHSCORE");
        if (highscore < 0) {
            highscoreText.text = "";
        } else {
            highscoreText.text = "Recorde: " + Mathf.FloorToInt(highscore).ToString();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        pontos += Time.deltaTime * multiplicadorPontos;
        pontosText.text = "Pontos: " + Mathf.FloorToInt(pontos).ToString();
        if (Input.GetKeyDown(KeyCode.UpArrow)) pular();
    }

   private void pular() 
    {
        if (estaNoChao) {
            rigidBody.AddForce(Vector2.up * forcaPulo);
            startAnimation("Pulando");
        }
    }

    private void FixedUpdate() {
        validaPlayerNoChao();
        if (rigidBody.velocity.y < limiarDeQueda) startAnimation("Caindo");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        configColisaoComInimigo(other);
    }

    private void configColisaoComInimigo(Collision2D other) {
        if (other.gameObject.CompareTag("Inimigo")) {
            atualizaEPersisteHighscore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void atualizaEPersisteHighscore() {
        if (pontos > highscore) {
            highscore = pontos;
            PlayerPrefs.SetFloat("HIGHSCORE", highscore);
        }
    }

    private void validaPlayerNoChao() {
        estaNoChao = Physics2D.Raycast(transform.position, Vector2.down, distanciaMinimaChao, layerChao);
        startAnimation("Andando");
    }

    private void startAnimation(string animation) {
        invalidateAnimations();
        animatorComponent.SetBool(animation, true);
    }

    private void invalidateAnimations() {
        animatorComponent.SetBool("Pulando", false);
        animatorComponent.SetBool("Caindo", false);
        animatorComponent.SetBool("Andando", false);
    }
}
