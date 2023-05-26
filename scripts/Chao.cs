using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chao : MonoBehaviour
{
    public float diferencaX;
    public float minX;

    void Update() {
        if (transform.position.x <= minX) {
            transform.position = new Vector3(
                transform.position.x + (diferencaX + 8) * 2,
                transform.position.y,
                transform.position.z);
        }
    }
}
