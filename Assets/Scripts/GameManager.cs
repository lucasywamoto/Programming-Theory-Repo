using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text timeText;       // Timer text
    public TMP_Text bestTimeText;   // Inside EndUI
    public GameObject EndUI;        // Panel for game over

    public bool isGameOver = false;

    private float gameTime = 0f;
    private float bestTime = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!isGameOver && timeText != null)
        {
            gameTime += Time.deltaTime;
            timeText.text = ((int)gameTime) + "s";
        }

        // // Reload scene on Space after game over
        // if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //     isGameOver = false;
        //     gameTime = 0f;
        //     Time.timeScale = 1f;
        // }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;

        if (timeText != null) timeText.gameObject.SetActive(false);

        // Update best time
        if (gameTime > bestTime) bestTime = gameTime;

        // Make sure EndUI and bestTimeText exist
        if (EndUI != null)
        {
            EndUI.SetActive(true);

            if (bestTimeText != null)
            {
                bestTimeText.text = "Best Time: " + (int)bestTime + "s";
            }
        }
    }
}
