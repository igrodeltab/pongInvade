using UnityEngine;
using TMPro;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameResultText;
    [SerializeField] private TextMeshProUGUI _pressAnyKeyText;
    [SerializeField] private BallMovement _ballMovement;
    [SerializeField] private PlayerPaddleMovement _playerPaddleMovement;
    [SerializeField] private EnemyPaddleAI _enemyPaddleAI;
    [SerializeField] private ScoreSystem _scoreSystem;

    public bool _gameStarted = false;

    private void Awake()
    {
        _gameResultText.text = _scoreSystem._winScore.ToString() + " goals to win";
        DisableGameplay();
    }

    private void Update()
    {
        if (!_gameStarted && Input.anyKeyDown)
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        _scoreSystem.ResetGameScoreUI();

        _gameStarted = true;
        _pressAnyKeyText.gameObject.SetActive(false);
        _gameResultText.gameObject.SetActive(false);

        _ballMovement.enabled = true;
        _ballMovement.RespawnBall();

        _playerPaddleMovement.enabled = true;
        _enemyPaddleAI.enabled = true;
    }

    public void DisableGameplay()
    {
        _gameStarted = false;

        _ballMovement.enabled = false;
        _playerPaddleMovement.enabled = false;
        _enemyPaddleAI.enabled = false;

        _pressAnyKeyText.gameObject.SetActive(true);
        _gameResultText.gameObject.SetActive(true);
    }

    public void ShowWinnerText(string resultText)
    {
        _gameResultText.text = resultText;
    }
}