using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorSerra : MonoBehaviour
{
    public GameObject[] inimigoPrefabList;
    public GameObject morcegoPrefab;
    public GameObject caveiraPrefab;
    public float delayInicial;
    public float delayEntreInimigos;
    public float distanciaMinima = 8;
    public float distanciaMaxima = 15;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GerarSerra());
    }

    // Update is called once per frame
    private IEnumerator GerarSerra()
    {
        yield return new WaitForSeconds(delayInicial);

        GameObject ultimoInimigoGerado = null;

        while (true)
        {
            var distanciaNecessaria = Random.Range(distanciaMinima, distanciaMaxima);

            var geracaoObjetoLiberada = ultimoInimigoGerado == null || Vector3.Distance(transform.position, ultimoInimigoGerado.transform.position) >= distanciaNecessaria;

            if (geracaoObjetoLiberada)
            {
                var dado = Random.Range(1, 12);

                if (dado <= 3)
                {
                    var posicaoYAleatoria = Random.Range(1.0f, 2.0f);
                    var posicao = new Vector3(
                        transform.position.x,
                        transform.position.y + posicaoYAleatoria,
                        transform.position.z
                    );
                    ultimoInimigoGerado = Instantiate(morcegoPrefab, posicao, Quaternion.identity);
                }
                if (dado > 3 && dado <= 7)
                {
                    var posicaoYAleatoria = Random.Range(1.0f, 2.0f);
                    var posicao = new Vector3(
                        transform.position.x,
                        transform.position.y + posicaoYAleatoria,
                        transform.position.z
                    );
                    ultimoInimigoGerado = Instantiate(caveiraPrefab, posicao, Quaternion.identity);
                }
                if (dado > 7 && dado <= 12)
                {
                    var posicaoAleatoria = Random.Range(0, inimigoPrefabList.Length);
                    var inimigoPrefab = inimigoPrefabList[0];
                    ultimoInimigoGerado = Instantiate(inimigoPrefab, transform.position, Quaternion.identity);
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
