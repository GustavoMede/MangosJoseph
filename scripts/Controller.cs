using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float forcaPulo;
    public LayerMask layerChao;
    private bool estaNoChao;
    public float distanciaMinimaChao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            pular();
        }
    }

   private void pular() 
    {
        if (estaNoChao) {
            rigidBody.AddForce(Vector2.up * forcaPulo);
        }
    }

    private void FixedUpdate() {
        estaNoChao = Physics2D.Raycast(transform.position, Vector2.down, distanciaMinimaChao, layerChao);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Inimigo")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
