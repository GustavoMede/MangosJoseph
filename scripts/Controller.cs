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
    private float multiplicadorPontos = 4.5f;
    public Text pontosText;
    public Animator animatorComponent;
    public float limiarDeQueda = -3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        pontos += Time.deltaTime * multiplicadorPontos;
        pontosText.text = Mathf.FloorToInt(pontos).ToString();
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
        if (other.gameObject.CompareTag("Inimigo")) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
