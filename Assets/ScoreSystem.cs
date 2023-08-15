using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerScoreText; // Ссылка на текстовый компонент для счета игрока
    [SerializeField] private TextMeshProUGUI _enemyScoreText; // Ссылка на текстовый компонент для счета врага

    private int _playerScore = 0; // Счет игрока
    private int _enemyScore = 0; // Счет врага

    private void Start()
    {
        UpdateScoreUI();
    }

    // Вызывается при попадании мяча в ворота игрока
    public void PlayerScored()
    {
        _playerScore++;
        UpdateScoreUI();
    }

    // Вызывается при попадании мяча в ворота врага
    public void EnemyScored()
    {
        _enemyScore++;
        UpdateScoreUI();
    }

    // Обновление текстового компонента счета
    private void UpdateScoreUI()
    {
        _playerScoreText.text = _playerScore.ToString();
        _enemyScoreText.text = _enemyScore.ToString();
    }
}