using UnityEngine;
using TMPro;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pressAnyKeyText;
    [SerializeField] private BallMovement _ballMovement;
    [SerializeField] private PlayerPaddleMovement _playerPaddleMovement;
    [SerializeField] private EnemyPaddleAI _enemyPaddleAI;

    private bool _gameStarted = false;

    private void Start()
    {
        _ballMovement.enabled = false;
        _playerPaddleMovement.enabled = false;
        _enemyPaddleAI.enabled = false;

        _pressAnyKeyText.gameObject.SetActive(true);
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
        _gameStarted = true;
        _pressAnyKeyText.gameObject.SetActive(false);

        _ballMovement.enabled = true;
        _playerPaddleMovement.enabled = true;
        _enemyPaddleAI.enabled = true;
    }
}