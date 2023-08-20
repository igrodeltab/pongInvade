using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerScoreText; // Ссылка на текстовый компонент для счета игрока
    [SerializeField] private TextMeshProUGUI _enemyScoreText; // Ссылка на текстовый компонент для счета врага
    [SerializeField] private GameInitializer _gameInitializer;

    private int _playerScore; // Счет игрока
    private int _enemyScore; // Счет врага
    public int _winScore;

    private void Awake()
    {
        ResetGameScoreUI();
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void ResetGameScoreUI()
    {
        _playerScore = 0;
        _enemyScore = 0;
        UpdateScoreUI();
    }

    // Вызывается при попадании мяча в ворота игрока
    public void PlayerScored()
    {
        _playerScore++;
        UpdateScoreUI();
        CheckScore();
    }

    // Вызывается при попадании мяча в ворота врага
    public void EnemyScored()
    {
        _enemyScore++;
        UpdateScoreUI();
        CheckScore();
    }

    // Обновление текстового компонента счета
    private void UpdateScoreUI()
    {
        _playerScoreText.text = _playerScore.ToString();
        _enemyScoreText.text = _enemyScore.ToString();
    }

    private void CheckScore()
    {
        if (_playerScore >= _winScore)
        {
            _gameInitializer.DisableGameplay();
            _gameInitializer.ShowWinnerText("you win");
        }

        if (_enemyScore >= _winScore)
        {
            _gameInitializer.DisableGameplay();
            _gameInitializer.ShowWinnerText("you lose");
        }
    }
}