using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // || Inspector References

    [SerializeField] private TextMeshProUGUI gameTimeText;
    [SerializeField] private TextMeshProUGUI numberOfEnemiesKilledText;

    // || State

    private int numberOfEnemiesKilled = 0;
    private float ellapsedTime = 0f;
    private bool isPlayerAlive = true;

    // || Cached References

    // || Properties

    public static GameManager Instance { get; private set; }

    public bool IsPlayerAlive { private get => isPlayerAlive; set => isPlayerAlive = value; }

    private void Awake()
    {
        Instance = this;
        ellapsedTime = 0f;
        numberOfEnemiesKilled = 0;
        UpdateUI();
    }

    private void Update()
    {
        ShowEllapsedTime();
    }

    public void UpdateNumberOfEnemiesKilled()
    {
        numberOfEnemiesKilled++;
        UpdateUI();
    }

    private void ShowEllapsedTime()
    {
        if (isPlayerAlive)
        {
            ellapsedTime += Time.deltaTime;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        if (gameTimeText && numberOfEnemiesKilledText)
        {
            gameTimeText.text = Formatter.FormatTime((int) ellapsedTime);
            numberOfEnemiesKilledText.text = string.Concat("x", numberOfEnemiesKilled);
        }
    }

    public void GameOver()
    {
        if (GameOverManager.Instance)
        {
            GameOverManager.Instance.ShowPanel(numberOfEnemiesKilled, (int) ellapsedTime);
        }
    }
}
