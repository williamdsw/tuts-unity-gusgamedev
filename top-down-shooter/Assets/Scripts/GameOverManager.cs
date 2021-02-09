using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    // || Inspector Elements

    [Header("UI")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI numberOfEnemiesKilledText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button quitButton;

    // || Cached References

    public static GameOverManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        if (playAgainButton && quitButton)
        {
            playAgainButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
            quitButton.onClick.AddListener(() => Application.Quit());
        }
    }

    public void ShowPanel(int numberOfEnemiesKilled, int ellapsedTime)
    {
        if (gameOverPanel && numberOfEnemiesKilledText && scoreText)
        {
            int score = (numberOfEnemiesKilled * (ellapsedTime * 10));
            numberOfEnemiesKilledText.text = string.Concat("Number Of Enemies Killed: ", numberOfEnemiesKilled);
            scoreText.text = string.Concat("Score: ", score);
            gameOverPanel.gameObject.SetActive(true);
        }
    }
}
