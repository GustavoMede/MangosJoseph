using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorSerra : MonoBehaviour
{
    public GameObject serraPrefab;
    public float delayInicial;
    public float delayEntreSerras;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GerarSerra", delayInicial, delayEntreSerras);
    }

    // Update is called once per frame
    void GerarSerra()
    {
        Instantiate(serraPrefab, transform.position, Quaternion.identity);
    }
}
