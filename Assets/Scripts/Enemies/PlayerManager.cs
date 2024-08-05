using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public bool isPlayerDead = false;
    public TMP_Text gameOverText;
    public Button restartButton;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        AssignUIElements();
        HideGameOverUI();
    }

    void AssignUIElements()
    {
        if (gameOverText == null)
        {
            gameOverText = GameObject.Find("GameOverText").GetComponent<TMP_Text>();
        }

        if (restartButton == null)
        {
            restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
            restartButton.onClick.AddListener(Restart); 
        }
    }

    private void HideGameOverUI()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }

        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerDead)
        {
            ShowGameOverUI();
        }
        else
        {
            HideGameOverUI();
        }
    }

    void ShowGameOverUI()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }

        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(true);
        }
    }

    public void Restart()
    {
        isPlayerDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
