using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public GameObject dialogBubble;

    private bool isGamePaused = true;
    public Text cliqueParaIniciarText;

    void Start()
    {
        Time.timeScale = 0f;
        dialogBubble.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cliqueParaIniciarText.enabled = false;
            dialogBubble.SetActive(false);
            Time.timeScale = 1f;
            isGamePaused = false;
        }
    }
}