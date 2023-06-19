using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public GameObject dialogBubble;

    private bool isGamePaused = true;
    public Text cliqueParaIniciarText;
    public Image direcionaisTutorialImage;
    public Text pularText;
    public Text agacharText;

    void Start()
    {
        pausaGame();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            desativaDialogos();
            iniciaJogo();
        }
    }

    private void pausaGame() {
        Time.timeScale = 0f;
        dialogBubble.SetActive(true);
    }

    private void desativaDialogos() {
        direcionaisTutorialImage.enabled = false;
        pularText.enabled = false;
        agacharText.enabled = false;
        cliqueParaIniciarText.enabled = false;
        dialogBubble.SetActive(false);
    }

    private void iniciaJogo() {
        Time.timeScale = 1f;
        isGamePaused = false;
    }
}