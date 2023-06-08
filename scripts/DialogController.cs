using UnityEngine;

public class DialogController : MonoBehaviour
{
    public GameObject dialogBubble;

    private bool isGamePaused = true;

    void Start()
    {
        Time.timeScale = 0f;
        dialogBubble.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dialogBubble.SetActive(false);
            Time.timeScale = 1f;
            isGamePaused = false;
        }
    }
}